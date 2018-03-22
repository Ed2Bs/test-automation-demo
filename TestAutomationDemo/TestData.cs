using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using NLog;
using OpenQA.Selenium;
using TestAutomationDemo.Infrastructure;

namespace TestAutomationDemo
{
    public class TestData
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private List<TestCase> testCases;

        private string randomNumber;
        public string RandomNumber => randomNumber ?? (randomNumber = RandomNo());

        private string randomString;
        public string RandomString => randomString ?? (randomString = RandomStr());

        public TestData() => testCases = JsonHelper.GetData();

        public void SetData(string testName, int testRound = 1)
        {
            List<TestDataValue> testData;
            Type activeModel;

            try
            {
                var testCase = testCases.FirstOrDefault(x => x.TestName == testName);

                activeModel = GetActiveModel(testCase);

                testData = testCase.PageModels
                                   .FirstOrDefault(x => x.PageModelName == activeModel.Name)
                                   .TestDataValues
                                   .Where(td => td.TestRound == testRound)
                                   .ToList();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

            foreach (var item in testData)
            {
                try
                {
                    var prop = activeModel.GetProperty(item.ElementIndentifier);
                    var propGetter = prop.GetGetMethod();
                    var o = propGetter.Invoke(Activator.CreateInstance(activeModel, new object[] { Service.Instance.Driver }), null);
                    var el = (IWebElement)o;

                    switch (item.ElementType)
                    {
                        case "Input":
                            SetValue(el, item.Value);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    throw;
                }
            }
        }

        private Type GetActiveModel(TestCase testCase)
        {
            var allPageModels = Assembly.GetExecutingAssembly()
                                        .GetTypes()
                                        .Where(type => type.GetCustomAttributes(typeof(PageModelAttribute)).Any())
                                        .ToDictionary(x => x, x => x.GetMethod("IsAt", BindingFlags.Instance | BindingFlags.NonPublic));

            var pageModels = testCase.PageModels
                                     .Select(p => allPageModels.FirstOrDefault(pm => pm.Key.Name == p.PageModelName))
                                     .ToDictionary(x => x.Key, x => x.Value);

            return pageModels
                .Where(x => Convert.ToBoolean(x.Value.Invoke(Activator.CreateInstance(x.Key, new object[] { Service.Instance.Driver }), null)))
                .FirstOrDefault()
                .Key;
        }

        private void SetValue(IWebElement el, string value)
        {
            var v = Map(value);

            foreach (var c in v)
            {
                el.SendKeys(c.ToString());
                Thread.Sleep(50);
            }

            logger.Info($"Entering data: {v}");
        }

        private string Map(string value)
        {
            string s;

            switch (value)
            {
                case "randomEmail()":
                    s = $"John{RandomNumber}@gmail.com";
                    break;
                case "randomName()":
                    s = $"John{RandomString}";
                    Globals.User.Name = s;
                    break;
                case "randomLastName()":
                    s = $"Doe{RandomString}";
                    Globals.User.LastName = s;
                    break;
                case "password()":
                    s = "SameOldSameOld";
                    break;
                default:
                    s = value;
                    break;
            }

            return s;
        }

        private string RandomNo() => new Random(Guid.NewGuid().GetHashCode()).Next().ToString().Substring(0, 6);

        private string RandomStr() =>
            new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 6).Select(s => s[new Random(Guid.NewGuid().GetHashCode()).Next(s.Length)]).ToArray());
    }
}