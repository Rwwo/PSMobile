using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Maui.ApplicationModel;

using PSMobile.DLLnet;
using PSMobile.SharedKernel.Common;

namespace PSMobile.SharedUI.Components.Pages.Teste;

public class GravarTestePage : MyBaseComponent
{

    public MeuNome MeuNomeInputModel { get; set; } = new();

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

    }


    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is MeuNome model)
            {
                var obj = new FormatNameTest(model.FirstName, model.LastName);

                var texto = obj.ReturnCompletedName();

                Snackbar.Add($"Meu nome é: {texto}", MudBlazor.Severity.Success);

            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, MudBlazor.Severity.Error);
        }
    }

}


public class MeuNome
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

