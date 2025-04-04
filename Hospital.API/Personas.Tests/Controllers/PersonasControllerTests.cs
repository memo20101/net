using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using Personas.API.Queries;
using Personas.API.Commands;
using Personas.API.Controllers;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http.Results;
using Personas.API.Domain.Entities;
using Personas.API.DTOs;

[TestClass]
public class PersonasControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private PersonasController _controller;

    [TestInitialize]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new PersonasController(_mediatorMock.Object);
    }

    [TestMethod]
    public async Task GetAll_ReturnsOk()
    {
        // Arrange
        var personas = new List<PersonaDto> { new PersonaDto { Id = 1, Nombre = "Guillermo" } };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllPersonasQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(personas);

        // Act
        IHttpActionResult result = await _controller.GetAll();
        var contentResult = result as OkNegotiatedContentResult<List<PersonaDto>>;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<PersonaDto>>));
        Assert.AreEqual(1, contentResult.Content.Count);
    }

    [TestMethod]
    public async Task GetById_ReturnsOk()
    {
        // Arrange
        var persona = new PersonaDto { Id = 1, Nombre = "Guillermo" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetPersonaByIdQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(persona);

        // Act
        IHttpActionResult result = await _controller.GetById(1);
        var contentResult = result as OkNegotiatedContentResult<PersonaDto>;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<PersonaDto>));
        Assert.AreEqual(1, contentResult.Content.Id);
    }

    [TestMethod]
    public async Task GetByTipo_ReturnsOk()
    {
        // Arrange
        var personas = new List<PersonaDto> { new PersonaDto { Id = 1, Nombre = "Guillermo", Tipo = TipoPersona.Medico } };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetPersonasByTipoQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(personas);

        // Act
        IHttpActionResult result = await _controller.GetByTipo(TipoPersona.Medico);
        var contentResult = result as OkNegotiatedContentResult<List<PersonaDto>>;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<PersonaDto>>));
        Assert.AreEqual(1, contentResult.Content.Count);
    }

    [TestMethod]
    public async Task Create_ReturnsCreated()
    {
        // Arrange
        var command = new CreatePersonaCommand { Nombre = "Guillermo" };
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreatePersonaCommand>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(1);

        // Act
        IHttpActionResult result = await _controller.Create(command);
        var createdResult = result as CreatedNegotiatedContentResult<int>;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(CreatedNegotiatedContentResult<int>));
        Assert.AreEqual(1, createdResult.Content);
    }

    [TestMethod]
    public async Task Update_ReturnsOk()
    {
        // Arrange
        var command = new UpdatePersonaCommand { Id = 1, Nombre = "Guillermo Editado" };
        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePersonaCommand>(), It.IsAny<CancellationToken>()))
                     .Returns((Task<Unit>)Task.CompletedTask);

        // Act
        IHttpActionResult result = await _controller.Update(1, command);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkResult));
    }

    [TestMethod]
    public async Task Delete_ReturnsOk()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<DeletePersonaCommand>(), It.IsAny<CancellationToken>()))
                     .Returns((Task<Unit>)Task.CompletedTask);

        // Act
        IHttpActionResult result = await _controller.Delete(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkResult));
    }
}