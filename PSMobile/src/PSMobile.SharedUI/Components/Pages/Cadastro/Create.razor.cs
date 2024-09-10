using MudBlazor;

using PSMobile.SharedKernel.Common;

using PSMobile.core.Entities;

namespace PSMobile.SharedUI.Components.Pages.Cadastro;
public class CreateCadastroPage : MyBaseComponent
{
    public Cadastros Cadastro { get; set; } = new Cadastros();

    public bool IsEditing { get; set; } = false;

    public void OnSubmit()
    {
        if (IsEditing)
            // Lógica para atualizar o cadastro existente
            Snackbar.Add("Cadastro atualizado com sucesso!", Severity.Success);
        else
        {
            // Lógica para adicionar novo cadastro
            Snackbar.Add("Cadastro adicionado com sucesso!", Severity.Success);
        }

        // Redirecionar após a operação
        Navigation.NavigateTo("/");
    }

    public void OnCancel()
    {
        Navigation.NavigateTo("/");
    }
}