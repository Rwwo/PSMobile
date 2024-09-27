using Xunit;
using Moq;
using PSMobile.api.Controllers;
using MediatR;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.application.Commands.Cadastros;
using PSMobile.core.ReturnFunctions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PSMobile.api.Tests;
public class CadastroControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<INotificador> _notificationMock;
    private readonly CadastrosController _controller;

    public CadastroControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _notificationMock = new Mock<INotificador>();
        _controller = new CadastrosController(_mediatorMock.Object, _notificationMock.Object);

        // Simular um ModelState válido no início
        _controller.ModelState.Clear();
    }

    [Fact]
    public async Task Post_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var inputModel = new CadastroInputModel { Nome = null }; // Nome é obrigatório, será inválido
        _controller.ModelState.AddModelError("Nome", "O Nome é obrigatório");

        // Act
        var result = await _controller.Post(inputModel);

        // Assert
        var badRequestResult = Assert.IsAssignableFrom<BadRequestObjectResult>(result); // Correto: Retorno é BadRequestObjectResult
        var errorMessages = Assert.IsAssignableFrom<List<string>>(badRequestResult.Value); // Correto: Verifica o conteúdo retornado
        Assert.Contains("O Nome é obrigatório", errorMessages);
    }

    [Fact]
    public async Task Post_ShouldReturnOk_WhenModelStateIsValid()
    {
        // Arrange
        var inputModel = new CadastroInputModel { Nome = "Teste Válido" };


        var commandResult = new ClienteGravarRetornoFuncao(0);
        _mediatorMock.Setup(m => m.Send(It.IsAny<GravarCadastroCommand>(), default))
                     .ReturnsAsync(commandResult);

        // Act
        var result = await _controller.Post(inputModel);

        // Assert
        var okResult = Assert.IsAssignableFrom<ObjectResult>(result); // Correto: Retorno é um ObjectResult
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode); // Correto: Verifica se o status é 200 (OK)
        Assert.Equal(commandResult, okResult.Value); // Correto: Verifica se o valor retornado é o resultado do comando
    }
}
