// CustomersUITests.cs
// CPSC 5210 - 01
// Purpose: Perform UI tests for Customers API for GetByid, GetAll, and Add

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Rent_A_Car_App_Backend_Project_UITests
{
    [TestFixture]
    public class CustomersUITests
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

        #region GetById
        [Test, Order(2)]
        public void Click_GetById_For_Customerss_Should_Return_TryItOut()
        {
            // Arrange
            // Wait for the Swagger UI to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(5000);
            // Find the "Customers" tag and click to expand
            IWebElement brandsTag = driver.FindElement(By.Id("operations-Customers-get_api_Customers_getbyid"));
            
            // Act
            brandsTag.Click();
            // Wait for the operation details to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(2000);
            // Find the "Try it Out" button
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));

            // Assert
            // Assert that the "Try it Out" button is displayed
            Assert.IsTrue(tryItOutButton.Displayed, "Try it Out button is not displayed");
        }

        [Test, Order(3)]
        public void Click_TryOut_And_Execute_For_Customers_Should_Return_Loading()
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
            System.Threading.Thread.Sleep(2000);
            var loadingElement = driver.FindElement(By.ClassName("loading"));

            // Assert
            // Assert that loading is displayed
            Assert.IsTrue(loadingElement.Enabled);

            System.Threading.Thread.Sleep(8000);
            driver.Navigate().Refresh();
        }
        #endregion

        #region GetAll
        [Test, Order(4)]
        public void Click_GetAll_For_Customers_Should_Return_TryItOut()
        {
            // Arrange
            // Wait for the Swagger UI to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(5000);
            // Find the "Customers" tag and click to expand
            IWebElement customersTag = driver.FindElement(By.Id("operations-Customers-get_api_Customers_getall"));

            // Act
            customersTag.Click();
            // Wait for the operation details to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(2000);
            // Find the "Try it Out" button
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));

            // Assert
            // Assert that the "Try it Out" button is displayed
            Assert.IsTrue(tryItOutButton.Displayed, "Try it Out button is not displayed");
        }

        [Test, Order(5)]
        public void Click_TryOut_In_GetAll_And_Execute_For_Customers_Should_Return_Loading()
        {
            // Arrange
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));
            tryItOutButton.Click();
            // Wait for the operation details to load 

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
        public void Click_Add_For_Customerss_Should_Return_TryItOut()
        {
            // Arrange
            // Wait for the Swagger UI to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(5000);
            // Find the "Customers" tag and click to expand
            IWebElement customersTag = driver.FindElement(By.Id("operations-Customers-post_api_Customers_add"));

            // Act
            customersTag.Click();
            // Wait for the operation details to load (adjust the wait time as needed)
            System.Threading.Thread.Sleep(2000);
            // Find the "Try it Out" button
            IWebElement tryItOutButton = driver.FindElement(By.XPath("//button[contains(text(),'Try it out')]"));

            // Assert
            // Assert that the "Try it Out" button is displayed
            Assert.IsTrue(tryItOutButton.Displayed, "Try it Out button is not displayed");
        }

        [Test, Order(7)]
        public void Click_TryOut_In_Add_And_Execute_For_Customers_Should_Return_Loading()
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
        }
        #endregion

        [OneTimeTearDown]
        public void TearDown()

        {
            driver.Quit();

        }

    }
}