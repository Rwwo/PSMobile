using MudBlazor;
using PSMobile.SharedKernel.Common;
using Microsoft.AspNetCore.Components.Forms;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Utilities.Interfaces;
using Microsoft.AspNetCore.Components;
using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common.Dtos.Extensions;

namespace PSMobile.SharedUI.Components.Pages.Cadastro;
public class GravarCadastroPage : MyBaseComponent
{
    public CadastroInputModel InputModel { get; set; } = new();
    public Cadastros? CurrentCadastro { get; set; } = new();
    [Inject] private ICadastroService CadService { get; set; } = null!;
    public List<Cidades> Cidades { get; set; } = new();
    public Cidades? Cidade { get; set; } = null;
    public bool IsEditing { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        Cidades = await ApiService.CidadesGetAllAsync();

        CurrentCadastro = ServiceLocal.Cadastro;

        if (CurrentCadastro is null)
            return;
        
        IsEditing = true;
        InputModel = CurrentCadastro.ToCadastrosInputModel();
        if (InputModel.CidCodigo is not null)
            Cidade = Cidades.SingleOrDefault(t => t.cid_codigo == InputModel.CidCodigo);

    }

    public async Task<IEnumerable<Cidades>> Search1(string value, CancellationToken clt)
    {
        await Task.Yield();

        // if text is null or empty, show complete list
        if (string.IsNullOrEmpty(value))
            return Cidades;

        var cidadesRet = Cidades.Where(x =>
                x.CidadeNormalizado.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                x.CidadeNormalizado.Equals(value, StringComparison.OrdinalIgnoreCase)
            ).ToList();


        return cidadesRet;
    }
    public void BuscarPeloCep()
    {
        if (InputModel.Cep?.Length < 7)
            return;

        var t = Cidades.SingleOrDefault(t => t.cid_cep == InputModel.Cep);

        if (t is not null)
        {
            Cidade = t;
            InputModel.UfsCodigo = t.cid_ufs_codigo;
        }


    }

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is CadastroInputModel model)
            {

                if (Cidade is not null)
                {
                    model.UfsCodigo = Cidade.cid_ufs_codigo;
                    model.CidCodigo = Cidade.cid_codigo;
                    model.CadPaiCodigo = Cidade.cid_pai_codigo;
                }


                var result = await CadService.GravarAsync(model);

                if (result.IsSuccess)
                {
                    if (IsEditing)
                        Snackbar.Add("Cadastro atualizado com sucesso!", Severity.Success);
                    else
                        Snackbar.Add("Cadastro adicionado com sucesso!", Severity.Success);


                    Navigation.NavigateTo("/cadastro");
                }
                else
                {
                    HandleError(result.Errors);
                }

            }

        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    public async Task OnInvalidSubmitAsync(EditContext editContext)
    {

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


