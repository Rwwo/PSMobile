using System.Net;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using PSMobile.application.Commands.Cadastros;
using PSMobile.application.Queries.Cadastros;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;

namespace PSMobile.api.Controllers
{
    [ApiController]
    [Route("api/v1/cadastros")]
    public class CadastrosController : MainController
    {
        private readonly IMediator _mediator;

        public CadastrosController(IMediator mediator, INotificador notificador)
            : base(notificador)
        {
            _mediator = mediator;
        }

        // Rota para buscar todos os cadastros
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetAllCadastrosQuery(pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return CustomResponse(HttpStatusCode.OK, result);
        }

        // Rota para buscar cadastro por chave
        [HttpGet("{cadKey:int}")]
        public async Task<IActionResult> GetByCadKey(int cadKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetCadastrosByCadKeyQuery(cadKey, pageSize, pageNumber);
            var result = await _mediator.Send(query);
            return CustomResponse(HttpStatusCode.OK, result);
        }

        // Rota para buscar cadastros por coluna personalizada
        [HttpGet("custom/{custom}")]
        public async Task<IActionResult> GetByCustomColumn(string custom, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllCustomColumnCadastrosQuery(custom, pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return CustomResponse(HttpStatusCode.OK, result);
        }

        [HttpGet("numdoc/{numdoc}")]
        public async Task<IActionResult> GetByNumDoc(string numdoc, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetCadastrosByNumDocQuery(numdoc, pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return CustomResponse(HttpStatusCode.OK, result);
        }

        // Rota para criar ou atualizar cadastro
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastroInputModel entity)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(messages);
            }

            var command = new GravarCadastroCommand(entity);
            var result = await _mediator.Send(command);
            return CustomResponse(HttpStatusCode.OK, result);
        }

    }
}
