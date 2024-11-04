
namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface INavigationService
{
    Task PushAsync(ContentPage page);
    Task PopAsync();
}
