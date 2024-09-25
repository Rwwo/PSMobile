using PSMobile.core.Notifications;

namespace PSMobile.core.Interfaces;

public interface INotificador
{
    bool HasNotify();
    List<Notificacao> GetNotify();
    void Handle(Notificacao notify);
}