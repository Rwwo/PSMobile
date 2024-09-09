using PSMobile.core.Interfaces;

namespace PSMobile.core.Notifications;

public class Notificador : INotify
{
    private List<Notify> _notificacoes;

    public Notificador()
    {
        _notificacoes = new List<Notify>();
    }

    public void Handle(Notify notificacao)
    {
        _notificacoes.Add(notificacao);
    }

    public List<Notify> GetNotify()
    {
        return _notificacoes;
    }

    public bool HasNotify()
    {
        return _notificacoes.Any();
    }
}
