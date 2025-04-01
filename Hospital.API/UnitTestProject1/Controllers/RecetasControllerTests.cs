using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recetas.API.Controllers;
using Recetas.API.Domain.Entities;
using Recetas.API.DTOs;
using Recetas.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace UnitTestProject1.Controllers
{
    [TestClass]
    public class RecetasControllerTests
    {
        private Mock<IRecetaUnitOfWork> _unitOfWorkMock;
        private Mock<IMapper> _mapperMock;
        private Recetas.API.Controllers.RecetasController _controller;

        [TestInitialize]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IRecetaUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _controller = new RecetasController(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public void Get_ReturnsOkResult_WithListOfRecetas()
        {
            // Arrange
            var recetas = new List<Receta>
            {
                new Receta { Id = 1, PacienteId = 123, MedicoId = 456, FechaEmision = System.DateTime.Now, Detalle = "Paracetamol 500mg" }
            };

            var recetasDto = new List<RecetaDto>
            {
                new RecetaDto { Id = 1, PacienteId = 123, MedicoId = 456, FechaEmision = System.DateTime.Now, Detalle = "Paracetamol 500mg" }
            };

            _unitOfWorkMock.Setup(u => u.Recetas.GetAll()).Returns(recetas);
            _mapperMock.Setup(m => m.Map<IEnumerable<RecetaDto>>(recetas)).Returns(recetasDto);

            // Act
            var actionResult = _controller.Get() as OkNegotiatedContentResult<IEnumerable<RecetaDto>>;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(1, actionResult.Content.ToList().Count);
        }

        [TestMethod]
        public void GetById_ReturnsNotFound_WhenRecetaDoesNotExist()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.Recetas.GetById(It.IsAny<int>())).Returns((Receta)null);

            // Act
            var actionResult = _controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Create_ReturnsCreatedAtRoute_WhenValid()
        {
            // Arrange
            var crearRecetaDto = new CrearRecetaDto
            {
                PacienteId = 123,
                MedicoId = 456,
                FechaEmision = System.DateTime.Now,
                Detalle = "Ibuprofeno 600mg"
            };

            var receta = new Receta { Id = 1 };
            var recetaDto = new RecetaDto { Id = 1 };

            _mapperMock.Setup(m => m.Map<Receta>(crearRecetaDto)).Returns(receta);
            _mapperMock.Setup(m => m.Map<RecetaDto>(receta)).Returns(recetaDto);

            // Act
            var actionResult = _controller.Create(crearRecetaDto);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<RecetaDto>));
        }

        [TestMethod]
        public void Delete_ReturnsNotFound_WhenRecetaDoesNotExist()
        {
            _unitOfWorkMock.Setup(u => u.Recetas.GetById(It.IsAny<int>())).Returns((Receta)null);

            var actionResult = _controller.Delete(1);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Delete_ReturnsOk_WhenRecetaExists()
        {
            var receta = new Receta { Id = 1 };
            _unitOfWorkMock.Setup(u => u.Recetas.GetById(It.IsAny<int>())).Returns(receta);

            var actionResult = _controller.Delete(1);

            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<string>));
        }
    }
}
