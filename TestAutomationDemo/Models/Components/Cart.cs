using System;
using NLog;
using OpenQA.Selenium;

namespace TestAutomationDemo.Models.Components
{
    public class Cart
    {
        public By ViewCart => By.XPath("//div[@class='shopping_cart']/a[@title='View my shopping cart']");
    }
}
