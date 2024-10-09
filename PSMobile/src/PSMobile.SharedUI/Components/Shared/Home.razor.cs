using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Common;

namespace PSMobile.SharedUI.Components.Shared;
public class HomePage : MyBaseComponent
{
    public PaginatedResult<Gerais> Geral { get; set; } = PaginatedResult<Gerais>.Empty(1, 1);

    public Empresas Empr { get; set; } = new();
    protected override async Task OnInitializedAsync()
    {

        var api = await UowAPI.GeraisService.GetAllAsync();
        ServiceLocal.SetarGerais(api);
        Empr = ServiceLocal.EmpresaAtual;


        await InvokeAsync(StateHasChanged);
        await base.OnInitializedAsync();
    }
}
