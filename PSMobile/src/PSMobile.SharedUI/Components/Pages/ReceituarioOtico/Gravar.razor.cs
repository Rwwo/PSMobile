using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Common;
using PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Component;
using PSMobile.SharedUI.Components.Shared;

using ZXing;

using static MudBlazor.Colors;

namespace PSMobile.SharedUI.Components.Pages.ReceituarioOtico;
public class GravarReceituarioOticoPage : MyBaseComponent
{
    public ReceituarioOculosInputModel InputModel { get; set; } = new();
    public ReceituarioOculos? CurrentReceituario { get; set; } = null;

    public bool IsEditing { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            CurrentReceituario = ServiceLocal.ReceituarioOculos;
            InputModel.AdicionarEmpresa(ServiceLocal.EmpresaAtual);

            var prescritores = await UowAPI.PrescritoresService.GetAllAsync(200, 1);
            InputModel.AdicionarPrescritores(prescritores.Items);

            var tiposMateriais = await UowAPI.TiposMateriaisService.GetAllAsync();
            InputModel.AdicionarTiposMateriais(tiposMateriais.Items);

            var funcionarios = await UowAPI.FuncionariosService.GetAllAsync(100, 1);
            InputModel.AdicionarVendedores(funcionarios.Items);

            if (CurrentReceituario is null)
                return;

            IsEditing = true;
            InputModel = InputModel.AdicionarExistente(CurrentReceituario);

        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }


    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is ReceituarioOculosInputModel model)
            {

                var result = await UowAPI.ReceituarioOticoService.GravarAsync(model);

                if (result.IsSuccess)
                {
                    if (IsEditing)
                        Snackbar.Add("Receituário atualizado com sucesso!", Severity.Success);
                    else
                        Snackbar.Add("Receituário cadastrado com sucesso!", Severity.Success);


                    ServiceLocal.LimparCliente();
                    Navigation.NavigateTo("/receituario-otico");
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

    public async Task OnInValidSubmitAsync(EditContext editContext)
    {
        try
        {
            Snackbar.Add("Verifique os campos e tente novamente");
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    public async Task ValidatedNumDocAsync()
    {
        var cpf = InputModel.cpf;

        if (string.IsNullOrEmpty(cpf))
        {
            ResetCustomerData();
            return;
        }

        FormatAndSyncCpf();

        if (string.IsNullOrEmpty(InputModel.Cadastros.cad_cnpj))
            return;

        var result = await UowAPI.CadastroService.GetByDocNumberAsync(cpf);

        if (result.Items.Any())
            SetCustomerData(result.Items.First());

        StateHasChanged();
    }

    private void FormatAndSyncCpf()
    {
        InputModel.cpf = PSSysService.PSFormatarCNPJ(InputModel.cpf);
        InputModel.Cadastros.cad_cnpj = InputModel.cpf;
    }

    private void ResetCustomerData()
    {
        InputModel.NomeCliente = string.Empty;
        InputModel.Cadastros = new();
    }


    public async Task SearchProductsDialogAsync()
    {
        try
        {
            await AddNewProductInPedidoAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }
    private async Task<DialogResult> OpenSearchProductDialogAsync()
    {
        var parameters = new DialogParameters();

        DialogOptions _options = new()
        {
            MaxWidth = MaxWidth.Large,
            FullScreen = IsMobile,
            CloseButton = true,
            CloseOnEscapeKey = true
        };

        var dialog = await DialogService.ShowAsync<SearchProductDialog>("Adicionar Produtos", parameters, _options);
        return await dialog.Result;
    }
    private async Task AddNewProductInPedidoAsync()
    {
        var dialogResult = await OpenSearchProductDialogAsync();

        if (!dialogResult.Canceled && dialogResult.Data is AddItemWithQtyInputModel input)
        {
            InputModel.recocu_pro_codigo = input.ProdutosEmpresas.Produto.pro_codigo;
        }
    }
    public async Task SearchCustomerDialogAsync()
    {
        var parameters = new DialogParameters();

        DialogOptions _options = new()
        {
            MaxWidth = MaxWidth.Large,
            FullScreen = IsMobile,
            CloseButton = true,
            CloseOnEscapeKey = true
        };

        var dialog = await DialogService.ShowAsync<SearchClientDialog>("Pesquisar Cliente", parameters, _options);
        var result = await dialog.Result;

        if (!result.Canceled && result.Data is Cadastros clienteSelecionado)
        {
            SetCustomerData(clienteSelecionado);
        }
    }

    private async Task SetCustomerData(Cadastros Cliente)
    {
        InputModel.Cadastros = Cliente;
        InputModel.NomeCliente = Cliente.cad_nome;
        InputModel.recocu_cad_key = Cliente.cad_key;

        if (Cliente.ClientesOtica is null)
        {
            var parameters = new DialogParameters<NovoClienteOticaComponent>
            {
                { x=> x.Cadastro , Cliente }
            };

            DialogOptions _options = new()
            {
                MaxWidth = MaxWidth.Large,
                FullScreen = IsMobile,
                CloseButton = true,
                CloseOnEscapeKey = true
            };

            var dialog = await DialogService.ShowAsync<NovoClienteOticaComponent>(
                "Atualize o cadastro ótica do cliente",
                 parameters,
                 _options
            );

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                //InputModel.recocu_clioti_key = ((ClienteOticaGravarRetornoFuncao)result.Data).codigo;
                InputModel.recocu_clioti_key = (int)result.Data;
            }
            
            dialog.Close();

            Console.WriteLine();
        }
        else
        {
            InputModel.recocu_clioti_key = Cliente.ClientesOtica.clioti_key;
        }
    }

    public async Task<IEnumerable<Funcionarios>> SearchEmployeeAsync(string value, CancellationToken token)
    {
        // In real life use an asynchronous function for fetching data from an api.
        await Task.Delay(5, token);

        // if text is null or empty, show complete list
        if (string.IsNullOrEmpty(value))
            return InputModel.Funcionarios;

        return InputModel.Funcionarios.Where(x => x.fun_nome.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<Prescritores>> SearchDoctorAsync(string value, CancellationToken token)
    {
        // In real life use an asynchronous function for fetching data from an api.
        await Task.Delay(5, token);

        // if text is null or empty, show complete list
        if (string.IsNullOrEmpty(value))
            return InputModel.Prescritores;

        return InputModel.Prescritores.Where(x => x.pre_nome.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}
