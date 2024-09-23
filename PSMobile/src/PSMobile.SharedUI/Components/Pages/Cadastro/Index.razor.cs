using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Common;

namespace PSMobile.SharedUI.Components.Pages.Cadastro;
public class IndexCadastroPage : MyBaseComponent
{

    public MudDataGrid<Cadastros> dataGrid;
    public string searchString = "";

    protected async override Task OnInitializedAsync()
    {
        IsLoading = true;
        IsLoading = false;

        await InvokeAsync(StateHasChanged);
        await base.OnInitializedAsync();
    }
    public async Task<GridData<Cadastros>> ServerReload(GridState<Cadastros> state)
    {
        int pageSize = dataGrid.RowsPerPage == 0 ? 10 : dataGrid.RowsPerPage;
        int pageNumber = dataGrid.CurrentPage == 0 ? 1 : dataGrid.CurrentPage;

        PaginatedResult<Cadastros> dados;

        if (string.IsNullOrEmpty(searchString))
        {
            dados = await UowAPI.CadastroService.GetAllAsync(pageSize, pageNumber);
        }
        else
        {
            dados = await UowAPI.CadastroService.GetByCustomColumnAsync(searchString, pageSize, pageNumber);
        }

        return new GridData<Cadastros>
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

    public void GoToUpdate(Cadastros input)
    {
        ServiceLocal.SetarCliente(input);
        Navigation.NavigateTo($"/cadastro/gravar");
    }

    public bool Search(Cadastros Cliente)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        if (Cliente.cad_nome is null)
            return false;

        if (Cliente.cad_nome.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }
}


