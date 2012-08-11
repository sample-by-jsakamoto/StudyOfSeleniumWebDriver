using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SharedStepDefinitions
{
    [Binding]
    public class StepDefinitionOfBrowser
    {
        public RemoteWebDriver Browser {
            get { return ScenarioContext.Current["Browser"] as RemoteWebDriver; }
            set { ScenarioContext.Current["Browser"] = value; }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Browser = new FirefoxDriver();
        }

        [When("Open URL (.+)")]
        public void OpenUrl(string url)
        {
            this.Browser.Navigate().GoToUrl(url);
        }

        [Then("Redirect to (.+)")]
        public void AssertUrl(string expectedUrl)
        {
            this.Browser.Url.Is(expectedUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Browser.Quit();
        }
    }
}
