using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Common;

namespace PSMobile.SharedUI.Components.Pages.Pedido;
public class IndexPedidosPage : MyBaseComponent
{
    public MudDataGrid<Pedidos> dataGrid;
    public string searchString = "";

    Empresas Empr = new Empresas();

    protected async override Task OnInitializedAsync()
    {
        Empr = ServiceLocal.EmpresaAtual;
    }

    public async Task<GridData<Pedidos>> ServerReload(GridState<Pedidos> state)
    {
        try
        {

            int pageSize = dataGrid.RowsPerPage == 0 ? 10 : dataGrid.RowsPerPage;
            int pageNumber = dataGrid.CurrentPage == 0 ? 1 : dataGrid.CurrentPage;

            PaginatedResult<Pedidos> dados;

            if (string.IsNullOrEmpty(searchString))
            {
                dados = await UowAPI.PedidoService.GetAllAsync(Empr.emp_key, pageSize, pageNumber);
            }
            else
            {
                dados = await UowAPI.PedidoService.GetByCustomColumnAsync(Empr.emp_key, searchString, pageSize, pageNumber);
            }

            return new GridData<Pedidos>
            {
                TotalItems = dados.TotalItems,
                Items = dados.Items
            };

        }
        catch (Exception ex)
        {
            HandleException(ex);

            return new GridData<Pedidos>
            {
                TotalItems = 0,
                Items = new List<Pedidos>()
            };

        }
    }

    public Task OnSearch(string text)
    {
        searchString = text;
        return dataGrid.ReloadServerData();
    }

    public void GoToUpdate(Pedidos input)
    {
        ServiceLocal.SetarPedido(input);
        Navigation.NavigateTo($"/pedidos/editar");
    }

    public void GoToAddPedido()
    {
        Navigation.NavigateTo($"/pedidos/gravar");
    }
}
