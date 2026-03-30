using Microsoft.AspNetCore.Mvc;
using Moq;
using NinetyOneTechnicalTestSolution.Controllers;
using NinetyOneTechnicalTestSolution.Models.DTOs;
using NinetyOneTechnicalTestSolution.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinetyOneTechnicalTestSolutionTests.ControllerTests
{
    public class MainControllerTests
    {
        private readonly Mock<IRepository> _mockRepository;
        private readonly MainController _controller;
        public MainControllerTests()
        {
            _mockRepository = new Mock<IRepository>();
            _controller = new MainController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllScores_ReturnsOkResult_WithScores()
        {
            // Arrange
            var scoresList = new List<Scores>
            {
                new() { Id = 1, FirstName = "John", LastName = "Doe", Score = 100 },
                new() { Id = 2, FirstName = "Jane", LastName = "Smith", Score = 90 }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync<Scores>()).ReturnsAsync(scoresList);
            // Act
            var result = await _controller.GetAllScores();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Scores>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public async Task GetTopScorers_ReturnOkResult_WithScorersInAlphabeticalOrder()
        {
            // Arrange
            var scoresList = new List<Scores>
            {
                new() { Id = 1, FirstName = "John", LastName = "Doe", Score = 100 },
                new() { Id = 2, FirstName = "Jane", LastName = "Smith", Score = 100 },
                new() { Id = 3, FirstName = "Alice", LastName = "Johnson", Score = 90 }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync<Scores>()).ReturnsAsync(scoresList);
            // Act
            var result = await _controller.GetTopScorers();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Scores>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            Assert.Equal("Jane", returnValue[0].FirstName);
            Assert.Equal("John", returnValue[1].FirstName);
        }
    }
}
