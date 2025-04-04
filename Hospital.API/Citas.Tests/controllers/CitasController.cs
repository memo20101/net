/*using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Web.Http;
using Citas.API.Commands;
using Citas.API.Controllers;
using Citas.API.Infrastructure.Messaging;
using Citas.API.Services;
using System.Threading;
using System.Web.Http.Results;

[TestClass]
public class CitasControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private Mock<IMapper> _mapperMock;
    private Mock<PersonasService> _personasServiceMock;
    private Mock<RabbitMQProducer> _rabbitMQProducerMock;
    private CitasController _controller;

    [TestInitialize]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
        _mapperMock = new Mock<IMapper>();
        _personasServiceMock = new Mock<PersonasService>();
        _rabbitMQProducerMock = new Mock<RabbitMQProducer>();

        _controller = new CitasController(
            _mediatorMock.Object,
            _mapperMock.Object,
            _personasServiceMock.Object,
            _rabbitMQProducerMock.Object
        );
    }

    [TestMethod]
    public async Task ProgramarCita_ReturnsOk()
    {
        // Arrange
        var command = new ProgramarCitaCommand { PacienteId = 1, MedicoId = 2 };

        _mediatorMock
            .Setup(m => m.Send<int>(It.IsAny<ProgramarCitaCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        IHttpActionResult result = await _controller.ProgramarCita(command);

        // Assert
        var okResult = result as OkNegotiatedContentResult<int>;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(1, okResult.Content);
    }
    [TestMethod]
    public async Task ProgramarCita_ReturnsBadRequest_WhenFails()
    {
        // Arrange
        var command = new ProgramarCitaCommand { PacienteId = 1, MedicoId = 2 };

        _mediatorMock
            .Setup(m => m.Send<int>(It.IsAny<ProgramarCitaCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(0); // Simulamos fallo

        // Act
        IHttpActionResult result = await _controller.ProgramarCita(command);

        // Assert
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
    }
    [TestMethod]
    public async Task ProgramarCita_ThrowsException_ReturnsInternalServerError()
    {
        // Arrange
        var command = new ProgramarCitaCommand { PacienteId = 1, MedicoId = 2 };

        _mediatorMock
            .Setup(m => m.Send<int>(It.IsAny<ProgramarCitaCommand>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new System.Exception("Error inesperado"));

        // Act
        IHttpActionResult result = await _controller.ProgramarCita(command);

        // Assert
        Assert.IsInstanceOfType(result, typeof(ExceptionResult));
    }
}
*/