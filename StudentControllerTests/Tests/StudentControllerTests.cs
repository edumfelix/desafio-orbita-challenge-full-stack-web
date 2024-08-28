using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Controllers.Data.ValueObject;
using WebApi.Repository;
using Moq;
namespace StudentControllerTests
{
    public class StudentControllerTests
    {
        private readonly Mock<IStudentRepository> _mockRepo;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _mockRepo = new Mock<IStudentRepository>();
            _controller = new StudentController(_mockRepo.Object);
        }

        [Fact]
        public async Task CreateStudentControllerTest_ShouldReturnOkResult_WhenStudentIsCreated()
        {
            // Arrange
            var studentVO = new StudentVO { Id = 1, Name = "Test Student", Email = "teststudent@mail.com", CPF = "11133344424", RA = "20212313145" };
            _mockRepo.Setup(repo => repo.Create(studentVO)).ReturnsAsync(studentVO);

            // Act
            var result = await _controller.Create(studentVO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<StudentVO>(okResult.Value);
            Assert.Equal(studentVO.Id, returnValue.Id);
        }

        [Fact]
        public async Task UpdateStudentControllerTest_ShouldReturnOkResult_WhenStudentIsUpdated()
        {
            // Arrange
            var studentVO = new StudentVO { Id = 1, Name = "Test Student", Email = "teststudent@mail.com", CPF = "11133344424", RA = "20212313145" };
            _mockRepo.Setup(repo => repo.Update(studentVO)).ReturnsAsync(studentVO);

            // Act
            var result = await _controller.Update(studentVO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<StudentVO>(okResult.Value);
            Assert.Equal(studentVO.Id, returnValue.Id);
        }

        [Fact]
        public async Task DeleteStudentControllerTest_ShouldReturnOkResult_WhenStudentIsDeleted()
        {
            // Arrange
            var studentId = 1;
            _mockRepo.Setup(repo => repo.Delete(studentId)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(studentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task DeleteStudentControllerTest_ShouldReturnBadRequest_WhenStudentIsNotDeleted()
        {
            // Arrange
            var studentId = 1;
            _mockRepo.Setup(repo => repo.Delete(studentId)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(studentId);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }


    }
}
