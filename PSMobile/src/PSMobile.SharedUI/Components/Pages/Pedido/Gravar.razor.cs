using System.Linq;

using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using MudExtensions;
using MudExtensions.Utilities;

using PSMobile.core.Entities;
using PSMobile.core.Extensions;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Common;
using PSMobile.SharedKernel.Utilities.Services;
using PSMobile.SharedUI.Components.Shared;

namespace PSMobile.SharedUI.Components.Pages.Pedido;

public class GravarPedidoPage : MyBaseComponent
{
    #region MudStepper
    public bool IsEditing { get; set; } = false;

    public MudStepperExtended? _stepper = new();
    public MudForm? _form = new();
    public MudForm? _form2 = new();
    public bool _checkValidationBeforeComplete = false;
    public bool _linear;
    public bool _iconActionButtons;
    public Variant _variant = Variant.Filled;
    public HeaderBadgeView _headerBadgeView = HeaderBadgeView.All;
    public HeaderTextView _headerTextView = HeaderTextView.All;
    public bool _animation = true;
    public bool _showPreviousButton = false;
    public bool _showNextButton = false;
    public bool _showSkipButton = false;
    public bool _showStepResultIndicator = false;
    public bool _addResultStep = false;
    public bool _customLocalization = true;
    public Color _color = Color.Primary;
    public int _activeIndex = 0;
    public bool _loading;
    public bool _showCustomButton = false;
    public bool _vertical = false;
    public Size _headerSize = Size.Medium;
    public StepperActionsJustify _stepperActionsJustify = StepperActionsJustify.SpaceBetween;


    public int _index;

    #endregion

    public PedidoInputModel PedidoInputModel { get; set; }
    public PaginatedResult<PedidosItens> PedidosItensPaginated { get; set; }
    public PaginatedResult<Funcionarios> FuncionariosPaginated { get; set; }
    public PaginatedResult<Pdvs> PdvsPaginated { get; set; }
    public PaginatedResult<FormasPagamento> FormasPagamentoPaginated { get; set; }



    private int emp_key = 0;
    public bool IsBothNFE_NFCe { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        emp_key = ServiceLocal.EmpresaAtual.emp_key;

        PedidoInputModel = new PedidoInputModel(emp_key);

        PdvsPaginated = await UowAPI.PdvService.GetAllAsync(emp_key, 1000, 1);
        FuncionariosPaginated = await UowAPI.FuncionariosService.GetAllAsync(1000, 1);
        FormasPagamentoPaginated = await UowAPI.FormasPagamentosService.GetAllAsync(100, 1);

        IsBothNFE_NFCe = PdvsPaginated.Items.Where(pdv => pdv.pdv_exc == 0 && pdv.pdv_emitenfe == 1).Count() > 0;

        await InvokeAsync(StateHasChanged);
        await base.OnInitializedAsync();

    }

    public async Task ValidarNumeroDocumento()
    {
        var aux = PedidoInputModel.Cliente.cad_cnpj;

        if (!string.IsNullOrEmpty(PedidoInputModel.Cliente.cad_cnpj))
        {
            PedidoInputModel.Cliente.cad_cnpj = PSSysService.PSFormatarCNPJ(PedidoInputModel.Cliente.cad_cnpj);
            if (!string.IsNullOrEmpty(PedidoInputModel.Cliente.cad_cnpj))
            {
                var ret = await UowAPI.CadastroService.GetByDocNumberAsync(aux);

                if (ret.Items.Count >= 1)
                    SetarDadosCliente(ret.Items[0]);
            }
        }
        else
        {
            PedidoInputModel.Cliente = new();
        }
    }

    private void SetarDadosCliente(Cadastros Cliente)
    {
        PedidoInputModel.Cliente = Cliente;
    }

    public void FinalizarPedido()
    {
        if (PedidoInputModel.CanFinish)
        {
            Snackbar.Add("Pode Finalizar", Severity.Success);
        }
        else
        {
            Snackbar.Add("Não Pode Finalizar", Severity.Error);
        }

    }
    public async void NewFormasPagamentos()
    {
        if (PedidoInputModel.SaldoRestante == 0)
        {
            Snackbar.Add("Não existe mais saldo restante para pagto.", Severity.Warning);
            return;
        }

        var aux = PedidoInputModel.CurrentPedido.PedidosFormasPagamento.ToList();

        PedidoInputModel.CurrentPedido.PedidosFormasPagamento.Clear();

        foreach (var item in aux)
        {
            var newForPagAux = new PedidosFormasPagamento()
            {
                pedforpag_forpag_codigo = item.pedforpag_forpag_codigo,
                pedforpag_ped_key = PedidoInputModel.CurrentPedido.ped_key,
                pedforpag_lancado = 0,
                pedforpag_valor = item.pedforpag_valor,
                PedidosFormasPagamentoParcelas = item.PedidosFormasPagamentoParcelas,
                FormaPagamento = item.FormaPagamento
            };

            PedidoInputModel.CurrentPedido.PedidosFormasPagamento.Add(newForPagAux);
        }

        var newForPag = new PedidosFormasPagamento()
        {
            pedforpag_ped_key = PedidoInputModel.CurrentPedido.ped_key,
            pedforpag_lancado = 0,
            pedforpag_valor = PedidoInputModel.SaldoRestante
        };

        PedidoInputModel.CurrentPedido.PedidosFormasPagamento.Add(newForPag);
        await InvokeAsync(StateHasChanged);
    }

    public async void ApagarFormasExistentesAsync()
    {
        PedidoInputModel.CurrentPedido.PedidosFormasPagamento.Clear();
        await InvokeAsync(StateHasChanged);
    }

    public async Task<DialogResult> ViewParcelasPagamento(PedidosFormasPagamento input)
    {
        var parameters = new DialogParameters<FormaPagamentoParcelasDialog>()
        {
            { c=> c.Data , input }
        };

        DialogOptions _options = new()
        {
            MaxWidth = MaxWidth.Large,
            FullScreen = IsMobile,
            CloseButton = true,
            CloseOnEscapeKey = true
        };

        var dialog = await DialogService.ShowAsync<FormaPagamentoParcelasDialog>("Visualizar Parcelas", parameters, _options);
        var dialogResult = await dialog.Result;

        if (!dialogResult.Canceled)
        {
            input.PedidosFormasPagamentoParcelas = (List<PedidosFormasPagamentoParcelas>)dialogResult.Data;
            return DialogResult.Ok(true);
        }

        return DialogResult.Cancel();

    }
    public async void DeleteFormaPagamento(PedidosFormasPagamento input)
    {
        PedidoInputModel.CurrentPedido.PedidosFormasPagamento.Remove(input);
        await InvokeAsync(StateHasChanged);
    }

    public async Task SearchProduct()
    {
        try
        {
            await SalvarPedido();
            await AdicionarProdutoAoPedidoAsync();

        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    private async Task AtualizarPedidoLocal(int pedKey)
    {
        var dadoPedido = await UowAPI.PedidoService.GetByPedKeyAsync(emp_key, pedKey);
        PedidoInputModel.CurrentPedido = dadoPedido.Items.FirstOrDefault();

        await InvokeAsync(StateHasChanged);
    }

    private async Task<Result<PedidosGravarRetornoFuncao>> GravarPedidoAsync()
    {
        return await UowAPI.PedidoService.GravarAsync(PedidoInputModel);
    }

    private async Task AdicionarProdutoAoPedidoAsync()
    {
        var dialogResult = await AbrirDialogoDeBuscaDeProdutoAsync();

        if (!dialogResult.Canceled && dialogResult.Data is AddItemWithQtyInputModel input)
        {
            await InserirItemAoPedidoAsync(input);
        }
    }

    private async Task<DialogResult> AbrirDialogoDeBuscaDeProdutoAsync()
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

    private async Task InserirItemAoPedidoAsync(AddItemWithQtyInputModel inputItem)
    {
        var input = new PedidoItemInputModel()
        {
            _item = 0,
            _pedite_datafab = null,
            _pedite_dataval = null,
            _pedite_desconto = 0,
            _pedite_lote = inputItem.ProdutosEmpresas.proemp_lote,
            _pedite_pro_codigo = inputItem.ProdutosEmpresas.Produto.pro_codigo,
            _pedite_nome = inputItem.ProdutosEmpresas.Produto.pro_nome,
            _pedite_qtd = inputItem.Qtde,
            _pedite_subtotal = decimal.Multiply(inputItem.Qtde, inputItem.ProdutosEmpresas.proemp_valor),
            _pedite_valorunitario = inputItem.ProdutosEmpresas.proemp_valor,
            _custo = inputItem.ProdutosEmpresas.proemp_custo,
            _pedite_total = decimal.Multiply(inputItem.Qtde, inputItem.ProdutosEmpresas.proemp_valor),
            _pro_nome = inputItem.ProdutosEmpresas.Produto.pro_nome,
            _usu = 0,
            _pedite_fun_key = PedidoInputModel.Funcionario != null ? PedidoInputModel.Funcionario.fun_key : 0,

            _emp_key = ServiceLocal.EmpresaAtual.emp_key,
            _pedite_ped_key = (int)PedidoInputModel._ped_key,
            _justificativa = string.Empty,
            _comput = Environment.MachineName,
        };

        var ret = await UowAPI.PedidoItemService.GravarAsync(input);

        if (ret.IsSuccess)
        {
            await AtualizarPedidoLocal((int)PedidoInputModel._ped_key);
        }
        else
        {
            HandleError(ret.Errors);
        }
    }



    public async Task SearchCustomer()
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
            SetarDadosCliente(clienteSelecionado);
        }
    }

    public async Task<IEnumerable<Funcionarios>> SearchEmployee(string value, CancellationToken token)
    {
        // In real life use an asynchronous function for fetching data from an api.
        await Task.Delay(5, token);

        // if text is null or empty, show complete list
        if (string.IsNullOrEmpty(value))
            return FuncionariosPaginated.Items;

        return FuncionariosPaginated.Items.Where(x => x.fun_nome.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public StepperLocalizedStrings GetLocalizedStrings()
    {
        return new StepperLocalizedStrings()
        {
            Completed = "Completo",
            Finish = "Finalizar",
            Next = "Próximo",
            Optional = "Opcional",
            Previous = "Voltar",
            Skip = "Pular",
            Skipped = "Pulado",
        };
    }

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is PedidoInputModel model)
            {

                var result = await UowAPI.PedidoService.GravarAsync(model);

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

    public async Task<bool> CheckChange(StepChangeDirection direction, int targetIndex)
    {
        await SalvarPedido();

        if (_checkValidationBeforeComplete == true)
        {
            // Always allow stepping backwards, even if forms are invalid
            if (direction == StepChangeDirection.Backward)
            {
                return false;
            }
            if (_stepper?.GetActiveIndex() == 0)
            {
                _loading = true;
                StateHasChanged();
                await Task.Delay(1000);
                await _form.Validate();
                _loading = false;
                StateHasChanged();
                return !_form.IsValid;
            }
            else if (_stepper?.GetActiveIndex() == 2)
            {
                _loading = true;
                StateHasChanged();
                await Task.Delay(1000);
                await _form2.Validate();
                _loading = false;
                StateHasChanged();
                return !_form2.IsValid;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public async Task StatusChanged(StepStatus status)
    {
        await Task.Delay(5);
    }

    private async Task SalvarPedido()
    {
        try
        {
            var result = await GravarPedidoAsync();
            if (!result.IsSuccess)
                HandleError(result.Errors);

            PedidoInputModel._ped_numero = result.Data._ped_numero;
            PedidoInputModel._ped_key = result.Data._ped_key;

            await AtualizarPedidoLocal(result.Data._ped_key);



        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }
}
