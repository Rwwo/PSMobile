using MudBlazor;
using Microsoft.AspNetCore.Components.Forms;
using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common;
using PSMobile.SharedKernel.Common.Dtos.Extensions;
using PSMobile.core.InputModel;

namespace PSMobile.SharedUI.Components.Pages.Cadastro;
public class GravarCadastroPage : MyBaseComponent
{
    public CadastroInputModel InputModel { get; set; } = new();
    public Cadastros? CurrentCadastro { get; set; } = new();
    public List<Cidades> Cidades { get; set; } = null!;
    public Cidades? Cidade { get; set; } = null;
    public bool IsEditing { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        var data = await UowAPI.CidadesService.GetAllAsync(10000, 1);
        Cidades = data.Items;

        CurrentCadastro = ServiceLocal.Cadastro;

        if (CurrentCadastro is null)
            return;

        IsEditing = true;
        InputModel = CurrentCadastro.ToInputModel();
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
    public void ValidarNumeroTelefone()
    {
        if (InputModel.Fone1 is not null)
            InputModel.Fone1 = PSSysService.PSFormatarFone(InputModel.Fone1);

        if (InputModel.Fone2 is not null)
            InputModel.Fone2 = PSSysService.PSFormatarFone(InputModel.Fone2);

        if (InputModel.Fone3 is not null)
            InputModel.Fone3 = PSSysService.PSFormatarFone(InputModel.Fone3);

        if (InputModel.FoneContato is not null)
            InputModel.FoneContato = PSSysService.PSFormatarFone(InputModel.FoneContato);
    }
    public void ValidarNumeroDocumento()
    {
        if (InputModel.Cnpj is not null)
            InputModel.Cnpj = PSSysService.PSFormatarCNPJ(InputModel.Cnpj);
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


                var result = await UowAPI.CadastroService.GravarAsync(model);

                if (result.IsSuccess)
                {
                    if (IsEditing)
                        Snackbar.Add("Cadastro atualizado com sucesso!", Severity.Success);
                    else
                        Snackbar.Add("Cadastro adicionado com sucesso!", Severity.Success);

                    ServiceLocal.LimparCliente();
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


