
using MudBlazor;

namespace PSMobile.SharedKernel.Utilities.Interfaces;
public interface IConfirmationDialogService
{
    Task<bool> ConfirmAsync(string title, string contentText, string buttonText = "Sim", Color color = Color.Success);
}