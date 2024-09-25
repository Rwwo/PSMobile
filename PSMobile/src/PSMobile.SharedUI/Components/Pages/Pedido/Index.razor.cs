using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Common;

namespace PSMobile.SharedUI.Components.Pages.Pedido;
public class IndexPedidosPage : MyBaseComponent
{
    public MudDataGrid<Pedidos> dataGrid;
    public string searchString = "";

    protected async override Task OnInitializedAsync()
    {
        await InvokeAsync(StateHasChanged);
        await base.OnInitializedAsync();
    }

    public async Task<GridData<Pedidos>> ServerReload(GridState<Pedidos> state)
    {
        int pageSize = dataGrid.RowsPerPage == 0 ? 10 : dataGrid.RowsPerPage;
        int pageNumber = dataGrid.CurrentPage == 0 ? 1 : dataGrid.CurrentPage;

        PaginatedResult<Pedidos> dados;

        if (string.IsNullOrEmpty(searchString))
        {
            dados = await UowAPI.PedidoService.GetAllAsync(pageSize, pageNumber);
        }
        else
        {
            dados = await UowAPI.PedidoService.GetByCustomColumnAsync(searchString, pageSize, pageNumber);
        }

        return new GridData<Pedidos>
        {
            TotalItems = dados.TotalItems,
            Items = dados.Items
        };
    }

    public Task OnSearch(string text)
    {
        searchString = text;
        return dataGrid.ReloadServerData();
    }

    public void GoToUpdate(Pedidos input)
    {
        ServiceLocal.SetarPedido(input);
        Navigation.NavigateTo($"/pedidos/gravar");
    }
}
