using FluentValidation;
using FluentValidation.Results;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

using PSMobile.core.Notifications;


namespace PSMobile.core.Services;
public abstract class BaseService
{
    private readonly INotify _notificador;

    public BaseService(INotify notificador)
    {
        _notificador = notificador;
    }

    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var item in validationResult.Errors)
        {
            Notificar(item.ErrorMessage);
        }
    }

    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notify(mensagem));
    }

    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade)
        where TV : AbstractValidator<TE>
        where TE : BaseEntity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid)
            return true;

        Notificar(validator);

        return false;
    }
}