using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.Maui.Devices;

using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Common;
public abstract class MyBaseComponent : ComponentBase
{
    [Inject] protected ILocalNavigationService ServiceLocal { get; set; } = null!;
    [Inject] protected ISnackbar Snackbar { get; set; } = null!;
    [Inject] protected IUowAPI UowAPI { get; set; } = null!;
    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
    [Inject] protected NavigationManager Navigation { get; set; } = null!;
    [Inject] protected IDialogService DialogService { get; set; } = null!;
    [Inject] protected IPssysValidacoesService PSSysService { get; set; } = null!;

    
    protected bool IsDense { get; private set; } = true;
    protected bool IsHover { get; private set; } = true;
    protected bool IsStriped { get; private set; } = true;
    protected bool IsBordered { get; private set; } = false;
    protected bool IsLoading { get; set; } = true;

    protected string RowsPerPageString { get; private set; } = "Itens por página";
    protected int[] PageSizeOptionsString { get; private set; } = { 10, 25, 50, 100, int.MaxValue };
    protected string InfoFormatString { get; private set; } = "{first_item}-{last_item} de {all_items}";

    protected void HandleError(List<string> ErrosApiService)
    {
        Snackbar.Add("Erro ao executar operação!", Severity.Warning, conf =>
        {
            conf.Action = "Detalhes";
            conf.ActionColor = Color.Info;
            conf.Onclick = snack =>
            {
                ShowDetails(string.Join('\n', ErrosApiService.ToArray()));
                return Task.CompletedTask;
            };
        });
    }
    protected void HandleException(Exception ex)
    {
        Snackbar.Add("Erro ao executar operação!", Severity.Warning, conf =>
        {
            conf.Action = "Detalhes";
            conf.ActionColor = Color.Info;
            conf.Onclick = snack =>
            {
                ShowDetails(ex.Message);
                return Task.CompletedTask;
            };
        });
    }

    private void ShowDetails(string message)
    {
        Snackbar.Add(message, Severity.Warning);
    }
    public bool IsMobile => IsMobileDevice();
    private bool IsMobileDevice()
    {
        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
        {
            return true;
        }
        return false;
    }


}

