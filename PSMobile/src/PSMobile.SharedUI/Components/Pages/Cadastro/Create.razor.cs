using MudBlazor;
using PSMobile.SharedKernel.Common;
using PSMobile.core.Entities;
using Microsoft.AspNetCore.Components.Forms;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Utilities.Services;
using PSMobile.SharedKernel.Utilities.Interfaces;
using Microsoft.AspNetCore.Components;

namespace PSMobile.SharedUI.Components.Pages.Cadastro;
public class CreateCadastroPage : MyBaseComponent
{
    public ClienteInputModel Cliente { get; set; } = new();
    [Inject] private ICadastroService CadService { get; set; } = null!;

    public bool IsEditing { get; set; } = false;

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        if (editContext.Model is ClienteInputModel model)
        {
            await CadService.GravarAsync(model);
        }

        if (IsEditing)
            Snackbar.Add("Cadastro atualizado com sucesso!", Severity.Success);
        else
            Snackbar.Add("Cadastro adicionado com sucesso!", Severity.Success);


        Navigation.NavigateTo("/cadastro");
    }

    public void OnCancel()
    {
        Navigation.NavigateTo("/");
    }
}