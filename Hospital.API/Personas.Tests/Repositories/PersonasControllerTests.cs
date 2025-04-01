using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Personas.API.Controllers;
using Personas.API.Domain.Entities;
using Personas.API.DTOs;
using Personas.API.Infrastructure.Data;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Personas.Tests.Repositories
{
    [TestClass]
    public class PersonasControllerTests
    {
        private Mock<IPersonaUnitOfWork> _unitOfWorkMock;
        private Mock<IMapper> _mapperMock;
        private PersonasController _controller;

        [TestInitialize]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IPersonaUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _controller = new PersonasController(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public void Get_ReturnsOkResult()
        {
            var personas = new List<Persona> { new Persona { Id = 1, Nombre = "Guillermo" } };
            var personasDto = new List<PersonaDto> { new PersonaDto { Id = 1, Nombre = "Guillermo" } };

            _unitOfWorkMock.Setup(u => u.Personas.GetAll()).Returns(personas);
            _mapperMock.Setup(m => m.Map<IEnumerable<PersonaDto>>(personas)).Returns(personasDto);

            var actionResult = _controller.Get() as OkNegotiatedContentResult<IEnumerable<PersonaDto>>;
            Assert.IsNotNull(actionResult);
        }
    }
}
