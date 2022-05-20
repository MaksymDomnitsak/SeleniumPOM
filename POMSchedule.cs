#nullable disable
using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{
    internal class POMSchedule
    {
        readonly string BaseURL = "http://develop-softserve.herokuapp.com/schedule";

        private IWebDriver driver;
        private WebDriverWait wait;

        public POMSchedule(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.CssSelector, Using= "nav.header-blocks:nth-child(3)>a:nth-child(1)")]
        [CacheLookup]
        public IWebElement headerBtn;

        [FindsBy(How = How.Id, Using = "group")]
        [CacheLookup]
        public IWebElement groupSelect;

        [FindsBy(How = How.Id, Using = "teacher")]
        [CacheLookup]
        public IWebElement teacherSelect;

        [FindsBy(How = How.Id, Using = "semester")]
        [CacheLookup]
        public IWebElement semesterSelect;

        [FindsBy(How = How.CssSelector, Using = "#root>div>section>section>div>form>button")]
        [CacheLookup]
        public IWebElement searchBtn;

        [FindsBy(How = How.CssSelector, Using = "#root>div>h1")]
        [CacheLookup]
        public IWebElement headerTitle;

        [FindsBy(How = How.CssSelector, Using = "#root>div>header>nav.header-blocks.header-blocks_two>a")]
        [CacheLookup]
        public IWebElement loginBtn;

        [FindsBy(How = How.CssSelector, Using = "#root>div>div>table")]
        [CacheLookup]
        public IWebElement scheduleTable;

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(BaseURL);
        }
        public void GoToPage()
        {

            wait.Until(d => headerBtn.Displayed);
            headerBtn.Click();

        }

        public void ChooseTeacher(string teacher)
        {

            wait.Until(d => teacherSelect.Enabled);
            var selectElement = new SelectElement(teacherSelect);
            selectElement.SelectByText(teacher);

        }

        public void SearchClick()
        {

            wait.Until(d => searchBtn.Displayed);
            searchBtn.Click();
            wait.Until(d => scheduleTable.Displayed);

        }

        public void ScheduleForTeacher(string teacher)
        {

            ChooseTeacher(teacher);
            SearchClick();

        }

        public string GetTextForHeader()
        {
            wait.Until(d => headerTitle.Displayed); 
            return headerTitle.Text;
        }

        public void ChooseGroup(string group)
        {

            wait.Until(d => groupSelect.Enabled);
            var selectElement = new SelectElement(groupSelect);
            selectElement.SelectByText(group);

        }

        public void ScheduleForGroup(string group)
        {

            ChooseGroup(group);
            SearchClick();
            wait.Until(d => scheduleTable.Displayed);
        }

        public void ChooseSemester(string semester)
        {

            wait.Until(d => semesterSelect.Enabled);
            var selectElement = new SelectElement(semesterSelect);
            selectElement.SelectByText(semester);

        }

        public void ScheduleForSemester(string semester)
        {

            ChooseSemester(semester);
            SearchClick();
            wait.Until(d => scheduleTable.Displayed);

        }
    }
}
