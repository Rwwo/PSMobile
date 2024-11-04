
using MudBlazor;

namespace PSMobile.SharedUI.Services;
public interface IConfirmationDialogService
{
    Task<bool> ConfirmAsync(string title, string contentText, string buttonText = "Sim", MudBlazor.Color color = MudBlazor.Color.Success);
}