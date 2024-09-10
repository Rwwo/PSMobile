using Microsoft.AspNetCore.Components;

using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common;
using PSMobile.SharedKernel.Utilities;

namespace PSMobile.SharedUI.Components.Pages.Cadastro;
public class IndexCadastroPage : MyBaseComponent
{
    [Inject] protected ICadastroService CadService { get; set; } = null!;
    public List<Cadastros> Cadastros { get; set; } = new();
    protected async override Task OnInitializedAsync()
    {
        await LoadDataAsync();
    }
    private async Task LoadDataAsync()
    {
        try
        {
            Cadastros = await CadService.GetAllAsync();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erro ao buscar dados: {ex.Message}");
        }
    }
}


