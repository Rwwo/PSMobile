using PSMobile.core.Notifications;

namespace PSMobile.core.Interfaces;

public interface INotify
{
    bool HasNotify();
    List<Notify> GetNotify();
    void Handle(Notify notify);
}