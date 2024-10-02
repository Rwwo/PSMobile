using Moq;
using PSMobile.api.Controllers;
using MediatR;
using PSMobile.core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PSMobile.application.Commands.Pedidos;
using PSMobile.core.InputModel;
using System.Net;
using Xunit;
using PSMobile.application.Queries.Pedidos;
using PSMobile.core.Entities;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.api.Tests;

public class PedidoControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<INotificador> _notificationMock;
    private readonly PedidosController _controller;

    public PedidoControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _notificationMock = new Mock<INotificador>();
        _controller = new PedidosController(_mediatorMock.Object, _notificationMock.Object);

        // Simular um ModelState válido no início
        _controller.ModelState.Clear();
    }


    [Fact]
    public async Task GetAll_DeveRetornarOk_ComDadosValidos()
    {
        // Arrange
        int empKey = 1;
        int pageNumber = 1;
        int pageSize = 10;

        // Criação de um objeto PaginatedResult com o tipo correto (Pedidos)
        var items = new List<Pedidos>
        {
            new Pedidos { /* Preencha os campos necessários */ },
            new Pedidos { /* Preencha os campos necessários */ }
        };

        var mockResponse = new PaginatedResult<Pedidos>(items, items.Count, pageNumber, pageSize);

        // Configuração do Mock para o IMediator
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllPedidosQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockResponse);

        // Act
        var result = await _controller.GetAll(empKey, pageNumber, pageSize);

        // Assert
        var okResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        Assert.Equal(mockResponse, okResult.Value);
    }




    [Fact]
    public async Task Post_GravarPedido_DeveRetornarBadRequest_QuandoModelInvalida()
    {
        // Arrange
        var pedidoInputModel = new PedidoAtualizarInputModel();
        _controller.ModelState.AddModelError("Nome", "O Nome é obrigatório");

        // Act
        var result = await _controller.Post(pedidoInputModel);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var errorMessages = Assert.IsType<List<string>>(badRequestResult.Value);
        Assert.Contains("O Nome é obrigatório", errorMessages);
    }

    [Fact]
    public async Task Post_GravarPedido_DeveRetornarOk_QuandoModelValida()
    {
        // Arrange
        var pedidoInputModel = new PedidoAtualizarInputModel
        {
            _ped_emp_key = 1,
            _ped_numero = 5432,
        };

        var mockResponse = new PedidosGravarRetornoFuncao("55|55");

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GravarPedidoCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockResponse);

        // Act
        var result = await _controller.Post(pedidoInputModel);

        // Assert
        var okResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        Assert.Equal(mockResponse, okResult.Value);
    }

    [Fact]
    public async Task Post_GravarPedidoItem_DeveRetornarBadRequest_QuandoModelInvalida()
    {
        // Arrange
        var pedidoItemInputModel = new PedidoItemInputModel();
        _controller.ModelState.AddModelError("Nome", "O Nome é obrigatório");

        // Act
        var result = await _controller.Post(pedidoItemInputModel);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var errorMessages = Assert.IsType<List<string>>(badRequestResult.Value);
        Assert.Contains("O Nome é obrigatório", errorMessages);
    }

    [Fact]
    public async Task Post_GravarPedidoItem_DeveRetornarOk_QuandoModelValida()
    {
        // Arrange
        var pedidoItemInputModel = new PedidoItemInputModel
        {
            _pedite_nome = "Item Teste"
        };

        var mockResponse = new PedidosItemGravarRetornoFuncao(5);

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GravarPedidoItemCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockResponse);

        // Act
        var result = await _controller.Post(pedidoItemInputModel);

        // Assert
        var okResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        Assert.Equal(mockResponse, okResult.Value);
    }

}
