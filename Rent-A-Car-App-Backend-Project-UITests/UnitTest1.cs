
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Rent_A_Car_App_Backend_Project_UITests
{
    public class Tests
    {

        IWebDriver driver;
        string filePath;
        [OneTimeSetUp]

        public void Setup()

        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            // Initalize file to upload & URL of website being tested
            string localURL = "https://localhost:44320/swagger/index.html";

            // Creates the ChomeDriver object, Executes tests on Google Chrome
            driver = new ChromeDriver(path + @"\drivers\");
            driver.Navigate().GoToUrl(localURL);
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void Title_Containing_Swagger_UI_Shows_That_App_Is_Open()

        {
            //System.Threading.Thread.Sleep(20000);
            Assert.IsTrue(driver.Title.Contains("Swagger UI"));

        }

        /*
        [Test]
        public void Uploading_HW1_File_Should_Return_Page_Which_Contains_HW1()
        {
            // Arrange
            c
            // Find the file input element
            var SelectFileButton = driver.FindElement(By.CssSelector(".select-files-button"));
            SelectFileButton.Click();

            //Act
            // Upload a PDF file
            IWebElement fileInput = driver.FindElement(By.CssSelector("input[type='file']"));
            fileInput.SendKeys(filePath);
            // after sending keys
            System.Threading.Thread.Sleep(30000);

            // Assert
            // Verify that the document is loaded (customize this based on the UI of the website)
            Assert.IsTrue(driver.PageSource.Contains("HW1"));
        }

        [Test]
        public void Navigating_To_Page4_And_Zooming_In_Should_Increase_Zoom_Level()
        {
            // Arrange
            // Switch to iframe that contains pages
            IWebElement iframeElement = driver.FindElement(By.Id("webviewer-1"));
            driver.SwitchTo().Frame(iframeElement);
            // wait for zoom option to be visible in UI
            System.Threading.Thread.Sleep(10000);
            // Find the zoom in button
            IWebElement zoomInButton = driver.FindElement(By.CssSelector("button[data-element='zoomInButton']"));
            // the current zoom level
            string initialZoomLevel = driver.FindElement(By.CssSelector("div[data-element='zoomOverlayButton'] input.textarea")).GetAttribute("value");

            // Act
            // Navigate to page 4 and click on the zoom in button
            IWebElement page4 = driver.FindElement(By.CssSelector("#pageThumb3 canvas.page-image")); //driver.FindElement(By.Id("pageThumb2"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", page4);
            zoomInButton.Click();
            // wait for the zoom to take effect
            System.Threading.Thread.Sleep(5000);

            // Assert
            // the new zoom level
            string updatedZoomLevel = driver.FindElement(By.CssSelector("div[data-element='zoomOverlayButton'] input.textarea")).GetAttribute("value");
            // Assert that the new zoom level is greater than the initial zoom level
            Assert.Greater(int.Parse(updatedZoomLevel), int.Parse(initialZoomLevel));
        }
        */

        [OneTimeTearDown]
        public void TearDown()

        {
            driver.Quit();

        }

    }
}