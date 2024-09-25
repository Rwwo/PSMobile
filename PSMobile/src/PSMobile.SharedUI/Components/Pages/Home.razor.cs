using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Common;

namespace PSMobile.SharedUI.Components.Pages;
public class HomePage : MyBaseComponent
{

    protected override async Task OnInitializedAsync()
    {
        ServiceLocal.SetarGerais(await UowAPI.CidadesService)


    }
}
