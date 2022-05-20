using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TestProject
{
    public class UnitTestPOM : IDisposable
    {
        IWebDriver driver;
        POMSchedule elem;
        public UnitTestPOM()
        {
            driver = new ChromeDriver();
            elem = new POMSchedule(driver);
            elem.GoToHomePage();
        }
        [Fact]
        public void CheckHeaderForTeacher()
        {
            elem.ScheduleForTeacher("Романенко Наталія Вікторівна");
            string headertext = elem.GetTextForHeader();
            Assert.True(headertext.Contains("Романенко Наталія Вікторівна"),"Header must contain :"+headertext);
        }

        [Fact]
        public void CheckHeaderForGroup()
        {
            elem.ScheduleForGroup("32 (302)");
            string headertext = elem.GetTextForHeader();
            Assert.True(headertext.Contains("32 (302)"), "Header must contain :" + headertext);
        }

        [Fact]
        public void CheckHeaderForSemester()
        {
            elem.ScheduleForSemester("1 2021- 2022");
            string headertext = elem.GetTextForHeader();
            Assert.True(headertext.Contains("1 2021- 2022"), "Header must contain :" + headertext);
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
