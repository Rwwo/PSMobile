using System.Net;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using PSMobile.application.Commands.Cadastros;
using PSMobile.application.Queries.Cadastros;
using PSMobile.application.Queries.Funcionarios;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Common.Dtos;

namespace PSMobile.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastrosController : MainController
    {
        private readonly IMediator _mediator;

        public CadastrosController(IMediator mediator, INotify notificador)
            : base(notificador)
        {
            _mediator = mediator;
        }

        // Rota para buscar todos os cadastros
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCadastrosQuery query)
        {
            var result = await _mediator.Send(query);
            return CustomResponse(HttpStatusCode.OK, result);
        }

        // Rota para buscar cadastro por chave
        [HttpGet("{cad_key:int}")]
        public async Task<IActionResult> GetByCadKey(int cad_key)
        {
            var query = new GetCadastrosByCadKeyQuery(cad_key);
            var result = await _mediator.Send(query);
            return CustomResponse(HttpStatusCode.OK, result);
        }

        // Rota para buscar cadastros por coluna personalizada
        [HttpGet("custom")]
        public async Task<IActionResult> GetByCustomColumn([FromQuery] GetAllCustomColumnCadastrosQuery query)
        {
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
