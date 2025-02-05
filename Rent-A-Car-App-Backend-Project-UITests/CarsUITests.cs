// CarUITests.cs
// CPSC 5210 - 01
// Purpose: Perform UI tests for Car API for GetCarByColorid, GetAll, and Add

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Rent_A_Car_App_Backend_Project_UITests
{
    [TestFixture]
    public class CarsUITests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()

        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            // Initalize file to upload & URL of website being tested
            string localURL = "https://localhost:44320/swagger/index.html";

            // Creates the ChomeDriver object, Executes tests on Google Chrome
            driver = new ChromeDriver(path + @"\drivers\");
            driver.Navigate().GoToUrl(localURL);
            System.Threading.Thread.Sleep(15000);
        }

        [Test, Order(1)]
        public void Title_Containing_Swagger_UI_Shows_That_App_Is_Open()

        {
            Assert.IsTrue(driver.Title.Contains("Swagger UI"));

        }

        [Test, Order(2)]
        public void Highlight_Car_Title()
        {
            // Id of the Car Title
            IWebElement element = driver.FindElement(By.Id("operations-tag-Cars"));

            // using js 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "border: 5px solid blue;");

            // 10 seconds waiting time
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        #region GetCarsByColorId
        [Test, Order(3)]
        public void Click_GetCarsByColorId_For_Cars_Should_Return_TryItOut()
        {
            // Arrange
            // Wait for the Swagger UI to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(5000);
            // Find the "Cars" tag and click to expand
            IWebElement CarsTag = driver.FindElement(By.Id("operations-Cars-get_api_Cars_getcarsbycolorid"));

            // Act
            CarsTag.Click();
            // Wait for the operation details to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(2000);
            // Find the "Try it Out" button
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));

            // Assert
            // Assert that the "Try it Out" button is displayed
            Assert.IsTrue(tryItOutButton.Displayed, "Try it Out button is not displayed");
        }

        [Test, Order(4)]
        public void Click_TryOut_And_Execute_For_Cars_Should_Return_Loading()
        {
            // Arrange
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));
            tryItOutButton.Click();
            // Wait for the operation details to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(2000);
            // Locate the second input using XPath indexing (index starts from 1)
            var secondInput = driver.FindElement(By.XPath("(//input[@type='text'])[1]"));
            // Perform actions on the second input
            secondInput.SendKeys("4");

            //Act
            // Locate the button by its class name
            var executeButton = driver.FindElement(By.XPath($"//button[contains(text(), 'Execute')]"));
            // Click on the "Execute" button
            executeButton.Click();

            // Assert
            // Assert that loading is displayed
            System.Threading.Thread.Sleep(2000);
            var loadingElement = driver.FindElement(By.ClassName("loading"));

            // Assert that the loading element is displayed
            Assert.IsTrue(loadingElement.Enabled);
            driver.Navigate().Refresh();
        }
        #endregion

        #region GetAll
        [Test, Order(4)]
        public void Click_GetAll_For_Cars_Should_Return_TryItOut()
        {
            // Arrange
            // Wait for the Swagger UI to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(5000);
            // Find the "Cars" tag and click to expand
            IWebElement carsTag = driver.FindElement(By.Id("operations-Cars-get_api_Cars_getall"));

            // Act
            carsTag.Click();
            // Wait for the operation details to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(2000);
            // Find the "Try it Out" button
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));

            // Assert
            // Assert that the "Try it Out" button is displayed
            Assert.IsTrue(tryItOutButton.Displayed, "Try it Out button is not displayed");
        }

        [Test, Order(5)]
        public void Click_TryOut_In_GetAll_And_Execute_For_Cars_Should_Return_Loading()
        {
            // Arrange
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));
            tryItOutButton.Click();
            // Wait for the operation details to load (adjust the wait time as needed)

            //Act
            // Locate the button by its class name
            var executeButton = driver.FindElement(By.XPath($"//button[contains(text(), 'Execute')]"));
            // Click on the "Execute" button
            executeButton.Click();

            // Assert
            // Assert that loading is displayed
            System.Threading.Thread.Sleep(2000);
            var loadingElement = driver.FindElement(By.ClassName("loading"));

            // Assert that the loading element is displayed
            Assert.IsTrue(loadingElement.Enabled);
            driver.Navigate().Refresh();
        }
        #endregion

        #region Add
        [Test, Order(6)]
        public void Click_Add_For_Cars_Should_Return_TryItOut()
        {
            // Arrange
            // Wait for the Swagger UI to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(5000);
            // Find the "Cars" tag and click to expand
            IWebElement carsTag = driver.FindElement(By.Id("operations-Cars-post_api_Cars_add"));

            // Act
            carsTag.Click();
            // Wait for the operation details to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(2000);
            // Find the "Try it Out" button
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));

            // Assert
            // Assert that the "Try it Out" button is displayed
            Assert.IsTrue(tryItOutButton.Displayed, "Try it Out button is not displayed");
        }

        [Test, Order(7)]
        public void Click_TryOut_In_Add_And_Execute_For_Cars_Should_Return_Loading()
        {
            // Arrange
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));
            tryItOutButton.Click();

            //Act
            // Locate the button by its class name
            var executeButton = driver.FindElement(By.XPath($"//button[contains(text(), 'Execute')]"));
            // Click on the "Execute" button
            executeButton.Click();

            // Assert
            // Assert that loading is displayed
            System.Threading.Thread.Sleep(2000);
            var loadingElement = driver.FindElement(By.ClassName("loading"));

            // Assert that the loading element is displayed
            Assert.IsTrue(loadingElement.Enabled);
        }
        #endregion

        [OneTimeTearDown]
        public void TearDown()

        {
            driver.Quit();

        }

    }
}