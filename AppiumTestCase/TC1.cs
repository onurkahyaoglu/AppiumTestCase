using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumTestCase
{
    public class TC1
    {
        AndroidDriver<AndroidElement> driver;
        DesiredCapabilities capabilities;

        [SetUp]
        public void InitDriver()
        {
            // Commandline da appium -a 127.0.0.1 -p 4723 komutu çalıştırılır.
            // Bu sayede server ayağa kaldırılmış olur
            // Sonrasında test yapılabilir

            capabilities = new DesiredCapabilities();
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("deviceName", "Pixel_4_API_30");
            capabilities.SetCapability("appPackage", "com.android.chrome");
            capabilities.SetCapability("appActivity", "com.google.android.apps.chrome.Main");

            Uri serverUri = new Uri("http://127.0.0.1:4723/wd/hub");
            driver = new AndroidDriver<AndroidElement>(serverUri, capabilities);
        }

        [Test]
        public void TestCase1()
        {
            driver.Navigate().GoToUrl("https://browseemall.com/");
        }
        [TearDown]
        public void closeDriver()
        {
            // Eğer kapatılmak istenirse bunlar açılabilir.
            //driver.CloseApp();
            //driver.Quit();
        }
    }
}
