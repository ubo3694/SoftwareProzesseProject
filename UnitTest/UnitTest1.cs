using Xunit;
using Moq;
using Assignment1.Controllers;
using Assignment1.Model;
using Microsoft.AspNetCore.Mvc;
using MVC_Frontend.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TrainingControllerUnitTest
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithTrainingsList()
        {
            // Arrange
            var mockRepository = new Mock<IMyRepository>();
            var trainings = new List<Training>
            {
                new Training { Id = 1, Start = DateTime.Now, End = DateTime.Now.AddHours(1), Duration = 60, Trainer = "Trainer1", Description = "Description1" },
                new Training { Id = 2, Start = DateTime.Now, End = DateTime.Now.AddHours(2), Duration = 120, Trainer = "Trainer2", Description = "Description2" }
            };

            mockRepository.Setup(repo => repo.GetAllTrainings()).ReturnsAsync(trainings);

            var controller = new TrainingController(mockRepository.Object);

            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ViewData);
            Assert.NotNull(result.ViewData.Model);

            var model = result.ViewData.Model as List<Training>;
            // Assert.Equal(2, model.Count);
            Assert.Equal(2, model?.Count); //Fehler

        }

        [Fact]
        public async Task Create_ValidTraining_RedirectsToIndex()
        {
            // Arrange
            var mockRepository = new Mock<IMyRepository>();
            var controller = new TrainingController(mockRepository.Object);
            var validTraining = new Training
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Duration = 60,
                Trainer = "Trainer3",
                Description = "Description3"
                // Set other properties
            };

            // Act
            var result = await controller.Create(validTraining) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async Task Details_ExistingTraining_ReturnsView()
        {
            // Arrange
            var mockRepository = new Mock<IMyRepository>();
            var existingTraining = new Training
            {
                Id = 1,
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
                Duration = 60,
                Trainer = "Trainer4",
                Description = "Description4"
                // Set other properties
            };

            mockRepository.Setup(repo => repo.GetTrainingById(existingTraining.Id)).ReturnsAsync(existingTraining);
            var controller = new TrainingController(mockRepository.Object);

            // Act
            var result = await controller.Details(existingTraining.Id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ViewData);
            Assert.NotNull(result.ViewData.Model);

            var model = result.ViewData.Model as Training;
            Assert.Equal(existingTraining.Id, model?.Id);
        }

        // Add more test methods as needed...

    }
}
