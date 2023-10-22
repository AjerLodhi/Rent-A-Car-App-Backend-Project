namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class ColorsControllerTests
    {
       
        [TestMethod]
        public void Test_GetBy_Id()
        {
            // Arrange
            var mockColorService = new Mock<IColorService>();
            mockColorService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new ColorResponse(true, "Success", new Color()));

            var controller = new ColorsController(mockColorService.Object);

            // Act
            var result = controller.GetById(1) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
           
        }
                [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            var mockColorService = new Mock<IColorService>();
            mockColorService.Setup(x => x.GetAll()).Returns(new ColorListResponse(true, "Success", new List<Color>()));

            var controller = new ColorsController(mockColorService.Object);

            // Act
            var result = controller.GetAll() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}