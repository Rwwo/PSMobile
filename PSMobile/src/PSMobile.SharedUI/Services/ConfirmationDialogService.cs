using MudBlazor;
using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedUI.Components.Shared;

namespace PSMobile.SharedKernel.Utilities.Services;

public class ConfirmationDialogService : IConfirmationDialogService
{
    private readonly IDialogService _dialogService;

    public ConfirmationDialogService(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    public async Task<bool> ConfirmAsync(string title, string contentText, string buttonText = "Sim", Color color = Color.Success)
    {
        var parameters = new DialogParameters
        {
            { "ContentText", contentText },
            { "ButtonText", buttonText },
            { "Color", color }
        };

        var options = new DialogOptions { CloseOnEscapeKey = true };

        var dialog = _dialogService.Show<ConfirmDialog>(title, parameters, options);
        var result = await dialog.Result;

        return !result.Canceled;
    }
}
