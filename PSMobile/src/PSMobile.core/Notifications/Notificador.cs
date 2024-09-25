using PSMobile.core.Interfaces;

namespace PSMobile.core.Notifications;

public class Notificador : INotificador
{
    private List<Notificacao> _notificacoes;

    public Notificador()
    {
        _notificacoes = new List<Notificacao>();
    }

    public void Handle(Notificacao notificacao)
    {
        _notificacoes.Add(notificacao);
    }

    public List<Notificacao> GetNotify()
    {
        return _notificacoes;
    }

    public bool HasNotify()
    {
        return _notificacoes.Any();
    }
}
