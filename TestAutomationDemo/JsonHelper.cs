using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TestAutomationDemo
{
    public static class JsonHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static List<TestCase> GetData()
        {
            List<TestCase> testCases = new List<TestCase>();

            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var json = File.ReadAllText(Path.Combine(path, ".\\Data\\testData.json"));
                var jo = JObject.Parse(json);

                testCases.AddRange(JsonConvert.DeserializeObject<List<TestCase>>(jo["testcases"].ToString()));
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

            return testCases;
        }
    }

    public class TestCase
    {
        public string TestName { get; set; }
        public List<PageModel> PageModels { get; set; }
    }

    public class PageModel
    {
        public string PageModelName { get; set; }
        public List<TestDataValue> TestDataValues { get; set; }
    }

    public class TestDataValue
    {
        public string ElementIndentifier { get; set; }
        public string ElementType { get; set; }
        public string Value { get; set; }
        public int TestRound { get; set; }
    }
}
