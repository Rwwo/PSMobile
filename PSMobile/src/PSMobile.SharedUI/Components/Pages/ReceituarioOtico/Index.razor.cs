using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Common;

namespace PSMobile.SharedUI.Components.Pages.ReceituarioOtico;
public class IndexReceituarioOticoPage : MyBaseComponent
{
    public MudDataGrid<ReceituarioOculos> dataGrid;
    public string searchString = "";

    public async Task<GridData<ReceituarioOculos>> ServerReload(GridState<ReceituarioOculos> state)
    {
        var empresa = ServiceLocal.EmpresaAtual;

        int pageSize = dataGrid.RowsPerPage == 0 ? 10 : dataGrid.RowsPerPage;
        int pageNumber = dataGrid.CurrentPage == 0 ? 1 : dataGrid.CurrentPage;

        PaginatedResult<ReceituarioOculos> dados;

        if (int.TryParse(searchString, out int numeroOs))
            dados = await UowAPI.ReceituarioOticoService.GetByIdAsync(numeroOs, pageSize, pageNumber);
        else
            dados = await UowAPI.ReceituarioOticoService.GetAllAsync(empresa.emp_key, pageSize, pageNumber);

        return new GridData<ReceituarioOculos>
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

    public void GoToUpdate(ReceituarioOculos input)
    {
        ServiceLocal.SetarReceituarioOtico(input);
        Navigation.NavigateTo($"/receituario-otico/gravar");
    }
    public void GoToAddReceituarioOculos()
    {
        ServiceLocal.LimparReceituarioOtico();
        Navigation.NavigateTo($"/receituario-otico/gravar");
    }
}
