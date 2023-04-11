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

            //Bu kısım emulator'ü kod üzerinden çalıştırmak için
            //ancak eğer bilgisayar çok hızlı değilse
            //time out hatası alınıyor. Bu yüzden emülator'ü manuel başlatarak da çalıştırabiliriz.

            capabilities.SetCapability("noReset", true);
            capabilities.SetCapability("automationName", "UiAutomator2");
            capabilities.SetCapability("avd", "Pixel_4_API_30");
            capabilities.SetCapability("avdLaunchTimeout", 1200000);
            capabilities.SetCapability("avdReadyTimeout", 1200000);
            capabilities.SetCapability("avdArgs", "-no-snapshot-load");
            capabilities.SetCapability("avdForceColdBoot", true); 
            capabilities.SetCapability("newCommandTimeout", 300000);
            capabilities.SetCapability("appWaitDuration", 300000);
            capabilities.SetCapability("testdroid_testTimeout", 12000);

            Uri serverUri = new Uri("http://127.0.0.1:4723/wd/hub");
            driver = new AndroidDriver<AndroidElement>(serverUri, capabilities);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
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
