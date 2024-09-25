using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using PSMobile.core.Interfaces;
using PSMobile.core.Notifications;

namespace PSMobile.api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotificador _notifier;

    protected MainController(INotificador notifier)
    {
        _notifier = notifier;
    }

    protected bool OperacaoValida()
    {
        return !_notifier.HasNotify();
    }

    protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
    {
        if (OperacaoValida())
        {
            return new ObjectResult(result)
            {
                StatusCode = Convert.ToInt32(statusCode),
            };
        }

        return BadRequest(new
        {
            errors = _notifier.GetNotify().Select(n => n.Message)
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            NotificarErroModelInvalida(modelState);

        return CustomResponse();
    }

    protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);
        foreach (var erro in erros)
        {
            var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotificarErro(errorMsg);
        }
    }

    protected void NotificarErro(string mensagem)
    {
        _notifier.Handle(new Notificacao(mensagem));
    }
}