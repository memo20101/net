using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Citas.API.Controllers;
using Citas.API.DTOs;
using Citas.API.Infrastructure;
using Citas.API.Domain;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Citas.API.Domain.Interfaces;
using AutoMapper;
using Citas.API.Domain.Entities;

namespace Citas.Tests.controllers
{
    [TestClass]
    public class CitasControllerTests
    {
        private Mock<ICitaUnitOfWork> _unitOfWorkMock;
        private Mock<IMapper> _mapperMock;
        private CitasController _controller;

        [TestInitialize]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<ICitaUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _controller = new CitasController(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public void Get_ReturnsOkResult_WithListOfCitas()
        {
            // Arrange
            var citas = new List<Cita>
            {
                new Cita { Id = 1, PacienteId = 10, MedicoId = 20, Motivo = "Consulta general" }
            };

            var citasDto = new List<CitaDTO>
            {
                new CitaDTO { Id = 1, PacienteId = 10, MedicoId = 20, Motivo = "Consulta general" }
            };

            _unitOfWorkMock.Setup(u => u.Citas.GetAll()).Returns(citas);
            _mapperMock.Setup(m => m.Map<IEnumerable<CitaDTO>>(It.IsAny<IEnumerable<Cita>>())).Returns(citasDto);

            // Act
            var actionResult = _controller.Get() as OkNegotiatedContentResult<IEnumerable<CitaDTO>>;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(1, actionResult.Content.ToList().Count);
        }

        [TestMethod]
        public void GetById_ReturnsNotFound_WhenCitaDoesNotExist()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.Citas.GetById(It.IsAny<int>())).Returns((Cita)null);

            // Act
            var actionResult = _controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Create_ReturnsCreatedAtRoute_WhenValid()
        {
            // Arrange
            var crearCitaDto = new CrearCitaDTO
            {
                PacienteId = 1,
                MedicoId = 2,
                Fecha = System.DateTime.Now,
                Motivo = "Chequeo general"
            };

            var cita = new Cita { Id = 1 };
            var citaDto = new CitaDTO { Id = 1 };

            _mapperMock.Setup(m => m.Map<Cita>(crearCitaDto)).Returns(cita);
            _mapperMock.Setup(m => m.Map<CitaDTO>(cita)).Returns(citaDto);

            // Act
            var actionResult = _controller.Create(crearCitaDto);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(CreatedAtRouteNegotiatedContentResult<CitaDTO>));
        }

        [TestMethod]
        public void Delete_ReturnsNotFound_WhenCitaDoesNotExist()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.Citas.GetById(It.IsAny<int>())).Returns((Cita)null);

            // Act
            var actionResult = _controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Delete_ReturnsOk_WhenCitaExists()
        {
            // Arrange
            var cita = new Cita { Id = 1 };
            _unitOfWorkMock.Setup(u => u.Citas.GetById(It.IsAny<int>())).Returns(cita);

            // Act
            var actionResult = _controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<string>));
        }
    } }
