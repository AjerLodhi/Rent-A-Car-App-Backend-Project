// CarsControllerTests.cs
 
using Core.Utilities.Result;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class CarsControllerTests
    {
        private readonly Mock<ICarService> _carServiceMock;
        private readonly CarsController _controller;

        public CarsControllerTests()
        {
            _carServiceMock = new Mock<ICarService>();
            _controller = new CarsController(_carServiceMock.Object);
        }

        #region GetAll

        [TestMethod]
        public void Getting_All_Cars_Returns_OK()
        {
            // Arrange
            var serviceResult = new SuccessDataResult<List<Car>>(new List<Car>(), "Cars retrieved successfully.");
            _carServiceMock.Setup(service => service.GetAll()).Returns((IDataResult<List<Car>>)serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Getting_All_Cars_Unsuccessfully_Returns_BadRequest()
        {
            // Arrange
            var serviceResult = new ErrorDataResult<List<Car>>("Failed to retrieve cars.");
            _carServiceMock.Setup(service => service.GetAll()).Returns((IDataResult<List<Car>>)serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        #endregion

        #region Add

        [TestMethod]
        public void Adding_Car_Returns_OK()
        {
            // Arrange
            var carToAdd = new Car(); // Provide necessary data for the car
            var serviceResult = new SuccessResult("Car added successfully.");
            _carServiceMock.Setup(service => service.Add(carToAdd)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(carToAdd);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Adding_Car_Unsuccessfully_Returns_BadRequest()
        {
            // Arrange
            var carToAdd = new Car(); // Provide necessary data for the car
            var serviceResult = new ErrorResult("Failed to add car.");
            _carServiceMock.Setup(service => service.Add(carToAdd)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(carToAdd);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        #endregion

        #region Update

        [TestMethod]
        public void Updating_Car_Returns_OK()
        {
            // Arrange
            var carToUpdate = new Car(); // Provide necessary data for the car
            var serviceResult = new SuccessResult("Car updated successfully.");
            _carServiceMock.Setup(service => service.Update(carToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(carToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Updating_Car_Unsuccessfully_Returns_BadRequest()
        {
            // Arrange
            var carToUpdate = new Car(); // Provide necessary data for the car
            var serviceResult = new ErrorResult("Failed to update car.");
            _carServiceMock.Setup(service => service.Update(carToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(carToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        #endregion

        #region Delete

        [TestMethod]
        public void Deleting_Car_Returns_OK()
        {
            // Arrange
            var carToDelete = new Car(); // Provide necessary data for the car
            var serviceResult = new SuccessResult("Car deleted successfully.");
            _carServiceMock.Setup(service => service.Delete(carToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(carToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Deleting_Car_Unsuccessfully_Returns_BadRequest()
        {
            // Arrange
            var carToDelete = new Car(); // Provide necessary data for the car
            var serviceResult = new ErrorResult("Failed to delete car.");
            _carServiceMock.Setup(service => service.Delete(carToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(carToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        #endregion

        #region GetById

        [TestMethod]

        public void Getting_Car_By_Id_Returns_OK()

        {

            // Arrange

            int carId = 1;

            var serviceResult = new SuccessDataResult<Car>(new Car(), "Car retrieved successfully.");

            _carServiceMock.Setup(service => service.GetById(carId)).Returns((IDataResult<Car>)serviceResult);

            // Act

            IActionResult result = _controller.GetById(carId);

            // Assert

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]

        public void Getting_Car_By_Id_Unsuccessfully_Returns_BadRequest()

        {

            // Arrange

            int carId = 1;

            var serviceResult = new ErrorDataResult<Car>(new Car(), ("Failed to retrieve car."));

            _carServiceMock.Setup(service => service.GetById(carId)).Returns((IDataResult<Car>)serviceResult);

            // Act

            IActionResult result = _controller.GetById(carId);

            // Assert

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        #endregion

        #region GetCarsByColorId

        [TestMethod]

        public void Getting_Cars_By_ColorId_Returns_OK()

        {

            // Arrange

            int colorId = 1;

            var serviceResult = new SuccessDataResult<List<Car>>(new List<Car>(), "Cars retrieved successfully.");

            _carServiceMock.Setup(service => service.GetCarsByColorId(colorId)).Returns((IDataResult<List<Car>>)serviceResult);

            // Act

            IActionResult result = _controller.GetCarsByColorId(colorId);

            // Assert

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]

        public void Getting_Cars_By_ColorId_Unsuccessfully_Returns_BadRequest()

        {

            // Arrange

            int colorId = 1;

            var serviceResult = new ErrorDataResult<List<Car>>("Failed to retrieve cars.");

            _carServiceMock.Setup(service => service.GetCarsByColorId(colorId)).Returns((IDataResult<List<Car>>)serviceResult);

            // Act

            IActionResult result = _controller.GetCarsByColorId(colorId);

            // Assert

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        #endregion

        #region GetCarsByBrandId

        [TestMethod]

        public void Getting_Cars_By_BrandId_Returns_OK()

        {

            // Arrange

            int brandId = 1;

            var serviceResult = new SuccessDataResult<List<Car>>(new List<Car>(), "Cars retrieved successfully.");

            _carServiceMock.Setup(service => service.GetCarsByBrandId(brandId)).Returns((IDataResult<List<Car>>)serviceResult);

            // Act

            IActionResult result = _controller.GetCarsByBrandId(brandId);

            // Assert

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]

        public void Getting_Cars_By_BrandId_Unsuccessfully_Returns_BadRequest()

        {

            // Arrange

            int brandId = 1;

            var serviceResult = new ErrorDataResult<List<Car>>("Failed to retrieve cars.");

            _carServiceMock.Setup(service => service.GetCarsByBrandId(brandId)).Returns((IDataResult<List<Car>>)serviceResult);

            // Act

            IActionResult result = _controller.GetCarsByBrandId(brandId);

            // Assert

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        #endregion

        #region GetCarDetails
        [TestMethod]
        public void Getting_Car_Details_Returns_OK()
        {
            // Arrange
            var serviceResult = new SuccessDataResult<List<Car>>(new List<Car>(), "Car details retrieved successfully.");
            _carServiceMock.Setup(service => service.GetAll()).Returns((IDataResult<List<Car>>)serviceResult);

            // Act
            IActionResult result = _controller.GetCarDetails();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Getting_Car_Details_Unsuccessfully_Returns_BadRequest()
        {
            // Arrange
            var serviceResult = new ErrorDataResult<List<Car>>("Failed to retrieve car details.");
            _carServiceMock.Setup(service => service.GetAll()).Returns((IDataResult<List<Car>>)serviceResult);

            // Act
            IActionResult result = _controller.GetCarDetails();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion
    }
}
