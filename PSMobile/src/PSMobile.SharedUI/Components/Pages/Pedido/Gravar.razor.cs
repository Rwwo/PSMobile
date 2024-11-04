using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using MudExtensions;
using MudExtensions.Utilities;

using PSMobile.core.Entities;
using PSMobile.core.Enums;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Common;
using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedKernel.Utilities.Services;
using PSMobile.SharedUI.Components.MauiPages;
using PSMobile.SharedUI.Components.Shared;
using PSMobile.SharedUI.Services;


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
    public MudBlazor.Color _color = MudBlazor.Color.Primary;
    public int _activeIndex = 0;
    public bool _loading;
    public bool _showCustomButton = false;
    public bool _vertical = false;
    public MudBlazor.Size _headerSize = MudBlazor.Size.Medium;
    public StepperActionsJustify _stepperActionsJustify = StepperActionsJustify.SpaceBetween;


    public int _index;

    #endregion

    [Inject] private ConfirmationDialogService ConfirmationDialogService { get; set; }
    public PedidoInputModel PedidoInputModel { get; set; }
    public PaginatedResult<PedidosItens> PedidosItensPaginated { get; set; }
    public PaginatedResult<Funcionarios> FuncionariosPaginated { get; set; }
    public PaginatedResult<Pdvs> PdvsPaginated { get; set; }
    public PaginatedResult<FormasPagamento> FormasPagamentoPaginated { get; set; }

    [Inject] protected INavigationService NaviPopUp { get; set; } = null;


    private int emp_key = 0;
    public bool IsBothNFE_NFCe { get; set; } = false;
    public bool IsOnlyNFCe { get; private set; }
    public string NomeBotaoFinaliza => PedidoInputModel.DimissEdit ? "Reabrir Pedido" : "Finalizar Pedido";
    protected override async Task OnInitializedAsync()
    {

        emp_key = ServiceLocal.EmpresaAtual.emp_key;
        PedidoInputModel = new PedidoInputModel(emp_key);

        PdvsPaginated = await UowAPI.PdvService.GetAllAsync(emp_key, 1000, 1);
        FuncionariosPaginated = await UowAPI.FuncionariosService.GetAllAsync(1000, 1);
        FormasPagamentoPaginated = await UowAPI.FormasPagamentosService.GetAllAsync(100, 1);

        IsBothNFE_NFCe = true;// PdvsPaginated.Items.Where(pdv => pdv.pdv_exc == 0 && pdv.pdv_emitenfe == 1).Count() > 0;
        IsOnlyNFCe = !(PdvsPaginated.Items.Where(pdv => pdv.pdv_exc == 0 && pdv.pdv_emitenfe == 1).Count() > 0);

        var input = ServiceLocal.Pedido;

        if (input != null)
        {
            await UpdatePedidoInMemoryAsync(input.ped_key);
        }
        else
        {
            await InvokeAsync(StateHasChanged);
        }

        await base.OnInitializedAsync();
    }

    public async Task ValidatedNumDocAsync()
    {
        var aux = PedidoInputModel.Cliente.cad_cnpj;

        if (!string.IsNullOrEmpty(PedidoInputModel.Cliente.cad_cnpj))
        {
            PedidoInputModel.Cliente.cad_cnpj = PSSysService.PSFormatarCNPJ(PedidoInputModel.Cliente.cad_cnpj);
            if (!string.IsNullOrEmpty(PedidoInputModel.Cliente.cad_cnpj))
            {
                var ret = await UowAPI.CadastroService.GetByDocNumberAsync(aux);

                if (ret.Items.Count >= 1)
                    SetCustomerData(ret.Items[0]);
            }
        }
        else
        {
            PedidoInputModel.Cliente = new();
        }
    }

    private void SetCustomerData(Cadastros Cliente)
    {
        PedidoInputModel.Cliente = Cliente;
        PedidoInputModel._ped_cad_key = Cliente.cad_key;
        PedidoInputModel._ped_nome = Cliente.cad_nome;

        Console.WriteLine(PedidoInputModel);
    }

    public async Task SaveFormasPagamentoAsync()
    {
        if (PedidoInputModel.CurrentPedido.PedidosFormasPagamento.Any() && PedidoInputModel.CanFinish)
        {
            await UowAPI.PedidoFormaPagamentoService.DeleteAsync(PedidoInputModel.CurrentPedido);

            var input = PedidoInputModel.CurrentPedido.PedidosFormasPagamento
                                                        .Select(x => new PedidoFormasPagamentoInputModel()
                                                        {
                                                            pedforpag_forpag_codigo = x.pedforpag_forpag_codigo,
                                                            pedforpag_ped_key = x.pedforpag_ped_key,
                                                            pedforpag_valor = x.pedforpag_valor,
                                                            ParcelasInputModel = x.PedidosFormasPagamentoParcelas.Select(y => new PedidoFormasPagamentoParcelaInputModel()
                                                            {
                                                                pedforpagpar_dataven = y.pedforpagpar_dataven,
                                                                pedforpagpar_forpag_codigo = y.pedforpagpar_forpag_codigo,
                                                                pedforpagpar_parcela = y.pedforpagpar_parcela,
                                                                pedforpagpar_parcelas = y.pedforpagpar_parcelas,
                                                                pedforpagpar_pedforpag_key = y.pedforpagpar_pedforpag_key,
                                                                pedforpagpar_titulo = y.pedforpagpar_titulo,
                                                                pedforpagpar_valor = y.pedforpagpar_valor,
                                                            }).ToList()
                                                        }).ToList();

            await UowAPI.PedidoFormaPagamentoService.GravarAsync(input);
        }
        else
        {
            Snackbar.Add("Você precisa completar as formas de pagamento", Severity.Info);
        }
    }

    public async Task GoToUpdate(PedidosItens Item)
    {

        var parameters = new DialogParameters<ConfirmQtdDialog>
        {
            { x => x.ContentText, $"Edição de quantidade: {Item.Produto.pro_codigo} - {Item.Produto.pro_nome}?" },
            { x => x.ButtonText, "Sim" },
            { x => x.Color, MudBlazor.Color.Success }
        };

        var dialog = await DialogService.ShowAsync<ConfirmQtdDialog>("Editar Quantidade", parameters);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            Snackbar.Add("Produto Atualizado", Severity.Success);

            var itemAdd = new EditItemWithQtyInputModel()
            {
                PedidosItens = Item,
                Qtde = (int)result.Data
            };


            var input = new PedidoItemInputModel()
            {
                _item = Item.pedite_item,
                _pedite_datafab = null,
                _pedite_dataval = null,
                _pedite_desconto = 0,
                _pedite_lote = Item.pedite_lote,
                _pedite_pro_codigo = Item.pedite_pro_codigo,
                _pedite_nome = Item.pedite_nome,
                _pedite_qtd = itemAdd.Qtde,
                _pedite_subtotal = decimal.Multiply(itemAdd.Qtde, Item.pedite_valorunitario),
                _pedite_valorunitario = Item.pedite_valorunitario,
                _custo = 0,
                _pedite_total = decimal.Multiply(itemAdd.Qtde, Item.pedite_valorunitario),
                _pro_nome = Item.Produto.pro_nome,
                _usu = 0,
                _pedite_fun_key = PedidoInputModel.Funcionario != null ? PedidoInputModel.Funcionario.fun_key : 0,

                _emp_key = ServiceLocal.EmpresaAtual.emp_key,
                _pedite_ped_key = (int)PedidoInputModel._ped_key,
                _justificativa = string.Empty,
                _comput = Environment.MachineName,
            };

            var resultPedidoItemService = await UowAPI.PedidoItemService.GravarAsync(input);

            if (resultPedidoItemService.IsSuccess)
            {
                await UpdatePedidoInMemoryAsync((int)PedidoInputModel._ped_key);
            }
            else
            {
                HandleError(resultPedidoItemService.Errors);
            }
        }
    }

    //CONTINUAR TESTANDO A EXCLUSÃO DE ITENS DO PEDIDO
    public async Task DeleteAsync(PedidosItens item)
    {
        try
        {
            var resultDialog = await ConfirmationDialogService.ConfirmAsync("Confirmar Exclusão", $"Confirma exclusão do item {item.pedite_nome}?");

            if (resultDialog)
            {
                await UowAPI.PedidoItemService.DeleteAsync(item);
                await UpdatePedidoInMemoryAsync(PedidoInputModel.CurrentPedido.ped_key);
            }
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    public async void FinishPedido()
    {
        try
        {
            await SaveFormasPagamentoAsync();

            if (!PedidoInputModel.DimissEdit)
            {
                if (PedidoInputModel.CanFinish)
                {
                    await ExecUpdateFunctionPedido(1);
                    Snackbar.Add("Pedido liberado para o caixa", Severity.Success);
                    Navigation.NavigateTo("/pedidos");
                }
                else
                {
                    var msg = new List<string>
                    {
                        "O Pedido não pode ser finalizado",
                        "Verifique se existem itens no pedido",
                        "Verifique se não existe saldo para informar formas de pagamento",
                    };
                    HandleMessageWithDetails("Atenção", msg);
                }
            }
            else
            {
                if (PedidoInputModel.CanFinish)
                {
                    await ExecUpdateFunctionPedido(0);
                    await UpdatePedidoInMemoryAsync(PedidoInputModel.CurrentPedido.ped_key);
                }
                else
                {
                    Snackbar.Add("Não Pode Finalizar", Severity.Error);
                }
            }

        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    private async Task ExecUpdateFunctionPedido(int finalizar = 0)
    {
        PedidoInputModel._ped_tipodocemitir = _index == 0 ? TipoDoc.NFCe : TipoDoc.NFe;

        var UpdatePedidoInputModel = new PedidoAtualizarInputModel
        {
            _ped_emp_key = emp_key,
            _ped_numero = PedidoInputModel._ped_numero,
            _ped_finalizado = finalizar,
            _ped_iddest = PedidoInputModel.CurrentPedido.ped_iddest,
            _ped_retira = PedidoInputModel.CurrentPedido.ped_retira,
            _ped_tipodocemitir = PedidoInputModel.CurrentPedido.ped_tipodocemitir,
            _ped_consumidorfinal = PedidoInputModel.CurrentPedido.ped_consumidorfinal,
        };

        var returnUpdate = await UowAPI.PedidoService.AtualizarAsync(UpdatePedidoInputModel);

        if (!returnUpdate.IsSuccess)
        {
            HandleMessageWithDetails("Atenção", returnUpdate.Errors);
        }
    }

    public async void NewFormasPagamentosAsync()
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

    public async void DeleteFormasPagamentoAsync()
    {
        if (PedidoInputModel.DescontoPercentual.HasValue || PedidoInputModel.DescontoReais.HasValue)
        {
            if (PedidoInputModel.CurrentPedido.PedidosFormasPagamento.Count() > 0)
            {
                var confirmed = await ConfirmationDialogService.ConfirmAsync("Atenção", "As formas de pagamento serão apagadas");
                if (!confirmed)
                    return;

                await UowAPI.PedidoFormaPagamentoService.DeleteAsync(PedidoInputModel.CurrentPedido);
                await UpdatePedidoInMemoryAsync(PedidoInputModel.CurrentPedido.ped_key);
            }
            else
            {
                PedidoInputModel.PedidosFormasPagamento.Clear();
            }

            await InvokeAsync(StateHasChanged);
        }
    }

    public async Task DeleteFormaPagamentoAsync(PedidosFormasPagamento input)
    {
        var confirmationMessage = "Confirma a exclusão da forma de pagamento?";
        var confirmationResult = await ConfirmationDialogService.ConfirmAsync("Atenção", confirmationMessage);

        if (confirmationResult)
        {
            if (input.pedforpag_key != 0)
            {
                // Deletar apenas uma forma de pagamento persistida
                await UowAPI.PedidoFormaPagamentoService.DeleteAsync(input);
                await UpdatePedidoInMemoryAsync(PedidoInputModel.CurrentPedido.ped_key);
            }
            else
            {
                // Remover a forma de pagamento em memória
                PedidoInputModel.CurrentPedido.PedidosFormasPagamento.Remove(input);
            }

        }
        // Atualizar a interface
        await InvokeAsync(StateHasChanged);
    }

    public async Task Recalcular()
    {
        Console.WriteLine(PedidoInputModel.SaldoRestante);
    }

    public async Task<DialogResult> ViewParcelasFormaPagamentoAsync(PedidosFormasPagamento input)
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

    public async Task OpenPopUp()
    {
        try
        {
            if (NaviPopUp == null)
                return;

            var camera = new CameraPage();
            await NaviPopUp.PushAsync(camera);
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }
    public async Task SearchProductsDialogAsync()
    {
        try
        {
            await SavePedidoAsync();
            await AddNewProductInPedidoAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    private async Task UpdatePedidoInMemoryAsync(int pedKey)
    {
        var dadoPedido = await UowAPI.PedidoService.GetByPedKeyAsync(emp_key, pedKey);
        PedidoInputModel.CurrentPedido = dadoPedido.Items.FirstOrDefault();
        PedidoInputModel._ped_obs = PedidoInputModel.CurrentPedido.ped_obs;
        PedidoInputModel._ped_key = PedidoInputModel.CurrentPedido.ped_key;
        PedidoInputModel._ped_numero = PedidoInputModel.CurrentPedido.ped_numero;
        PedidoInputModel.Funcionario = PedidoInputModel.CurrentPedido.Funcionario;
        PedidoInputModel.Cliente = PedidoInputModel.CurrentPedido.Cliente;

        _index = (PedidoInputModel.CurrentPedido.ped_tipodocemitir == TipoDoc.NFCe) ? 0 : 1;

        await InvokeAsync(StateHasChanged);
    }

    private async Task<Result<PedidosGravarRetornoFuncao>> GravarPedidoServiceAsync()
    {
        PedidoInputModel._ped_obs = PedidoInputModel.CurrentPedido.ped_obs;
        PedidoInputModel._ped_nome = PedidoInputModel.Cliente.cad_nome;
        PedidoInputModel._ped_cad_key = PedidoInputModel.Cliente.cad_key;
        PedidoInputModel._ped_fun_key = PedidoInputModel.Funcionario.fun_key != 0 ? PedidoInputModel.Funcionario.fun_key : null;
        return await UowAPI.PedidoService.GravarAsync(PedidoInputModel);
    }

    private async Task AddNewProductInPedidoAsync()
    {
        var dialogResult = await OpenSearchProductDialogAsync();

        if (!dialogResult.Canceled && dialogResult.Data is AddItemWithQtyInputModel input)
        {
            await AddProductAsync(input);
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

    private async Task AddProductAsync(AddItemWithQtyInputModel inputItem)
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

        var resultPedidoItemService = await UowAPI.PedidoItemService.GravarAsync(input);

        if (resultPedidoItemService.IsSuccess)
        {
            await UpdatePedidoInMemoryAsync((int)PedidoInputModel._ped_key);
        }
        else
        {
            HandleError(resultPedidoItemService.Errors);
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

    public async Task<IEnumerable<Funcionarios>> SearchEmployeeAsync(string value, CancellationToken token)
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
        await SavePedidoAsync();

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

    private async Task SavePedidoAsync()
    {
        try
        {
            if (PedidoInputModel.CurrentPedido.ped_finalizado == 1)
                return;

            var result = await GravarPedidoServiceAsync();
            if (!result.IsSuccess)
                HandleError(result.Errors);

            PedidoInputModel._ped_numero = result.Data._ped_numero;
            PedidoInputModel._ped_key = result.Data._ped_key;

            await ExecUpdateFunctionPedido(0);

            await UpdatePedidoInMemoryAsync(result.Data._ped_key);


        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }
}
