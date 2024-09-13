using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.Maui.Networking;

using MudBlazor;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Common;
public abstract class MyBaseComponent : ComponentBase
{
    [Inject] protected ILocalNavigationService ServiceLocal { get; set; } = null!;
    [Inject] protected ISnackbar Snackbar { get; set; } = null!;
    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
    [Inject] protected NavigationManager Navigation { get; set; } = null!;
    [Inject] protected IDialogService DialogService { get; set; } = null!;

    protected bool IsDense { get; private set; } = true;
    protected bool IsHover { get; private set; } = true;
    protected bool IsStriped { get; private set; } = true;
    protected bool IsBordered { get; private set; } = false;
    protected bool IsLoading { get; set; } = true;

    protected string RowsPerPageString { get; private set; } = "Itens por página";
    protected int[] PageSizeOptionsString { get; private set; } = { 10, 25, 50, 100, int.MaxValue };
    protected string InfoFormatString { get; private set; } = "{first_item}-{last_item} de {all_items}";

}
