using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Common;

namespace PSMobile.SharedUI.Components.Pages.OrdemServico;
public class IndexOrdemServicoPage : MyBaseComponent
{
    public MudDataGrid<OrdensServicos> dataGrid;
    public string searchString = "";

    Empresas Empr = new Empresas();

    protected async override Task OnInitializedAsync()
    {
        Empr = ServiceLocal.EmpresaAtual;
    }

    public async Task<GridData<OrdensServicos>> ServerReload(GridState<OrdensServicos> state)
    {
        try
        {

            int pageSize = dataGrid.RowsPerPage == 0 ? 10 : dataGrid.RowsPerPage;
            int pageNumber = dataGrid.CurrentPage == 0 ? 1 : dataGrid.CurrentPage;

            PaginatedResult<OrdensServicos> dados;

            if (string.IsNullOrEmpty(searchString))
            {
                dados = await UowAPI.OrdemServicoService.GetAllAsync(Empr.emp_key, pageSize, pageNumber);
            }
            else
            {
                dados = await UowAPI.OrdemServicoService.GetByCustomColumnAsync(Empr.emp_key, searchString, pageSize, pageNumber);
            }

            return new GridData<OrdensServicos>
            {
                TotalItems = dados.TotalItems,
                Items = dados.Items
            };

        }
        catch (Exception ex)
        {
            HandleException(ex);

            return new GridData<OrdensServicos>
            {
                TotalItems = 0,
                Items = new List<OrdensServicos>()
            };

        }
    }

    public Task OnSearch(string text)
    {
        searchString = text;
        return dataGrid.ReloadServerData();
    }

    public void GoToUpdate(OrdensServicos input)
    {
        ServiceLocal.SetarOS(input);
        Navigation.NavigateTo($"/ordens-servicos/gravar");
    }

    public void GoToAddOS()
    {
        ServiceLocal.LimparOS();
        Navigation.NavigateTo($"/ordens-servicos/gravar");
    }
}
