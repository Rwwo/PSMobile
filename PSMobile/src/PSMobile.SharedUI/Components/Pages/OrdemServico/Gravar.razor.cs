using MudBlazor;
using Microsoft.AspNetCore.Components.Forms;
using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common;
using PSMobile.SharedKernel.Common.Dtos.Extensions;
using PSMobile.core.InputModel;
using MudExtensions;
using Microsoft.AspNetCore.Components;
using MudExtensions.Utilities;
using PSMobile.core.Enums;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.SharedKernel.Utilities.Services;
using PSMobile.SharedUI.Components.Shared;
using PSMobile.SharedUI.Services;
using static MudBlazor.CategoryTypes;
using static MudBlazor.Icons;

namespace PSMobile.SharedUI.Components.Pages.OrdemServico;
public class GravarOrdemServicoPage : MyBaseComponent
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


    public OrdensServicosInputModel OSInputModel { get; set; } = new();
    public OrdensServicos? CurrentOS { get; set; } = new();
    public List<Cidades> Cidades { get; set; } = null!;
    public Cidades? Cidade { get; set; } = null;

    [Inject] private ConfirmationDialogService ConfirmationDialogService { get; set; }
    public PaginatedResult<OrdensServicosItens> OSItensPaginated { get; set; }
    public PaginatedResult<Funcionarios> FuncionariosPaginated { get; set; }


    private int emp_key = 0;

    public string NomeBotaoFinaliza => OSInputModel.DimissEdit ? "Reabrir O.S." : "Finalizar O.S";

    protected override async Task OnInitializedAsync()
    {
        emp_key = ServiceLocal.EmpresaAtual.emp_key;
        OSInputModel = new OrdensServicosInputModel(emp_key);

        FuncionariosPaginated = await UowAPI.FuncionariosService.GetAllAsync(1000, 1);

        var input = ServiceLocal.OrdemServico;

        if (input != null)
        {
            await UpdateOSInMemoryAsync(input.ordser_key);
        }
        else
        {
            await InvokeAsync(StateHasChanged);
        }

        await base.OnInitializedAsync();
    }

    public async Task ValidatedNumDocAsync()
    {
        var aux = OSInputModel.Cliente.cad_cnpj;

        if (!string.IsNullOrEmpty(OSInputModel.Cliente.cad_cnpj))
        {
            OSInputModel.Cliente.cad_cnpj = PSSysService.PSFormatarCNPJ(OSInputModel.Cliente.cad_cnpj);
            if (!string.IsNullOrEmpty(OSInputModel.Cliente.cad_cnpj))
            {
                var ret = await UowAPI.CadastroService.GetByDocNumberAsync(aux);

                if (ret.Items.Count >= 1)
                    SetCustomerData(ret.Items[0]);
            }
        }
        else
        {
            OSInputModel.Cliente = new();
        }
    }

    private void SetCustomerData(Cadastros Cliente)
    {
        OSInputModel.Cliente = Cliente;
        OSInputModel._ordser_cad_key = Cliente.cad_key;
        OSInputModel._ordser_nome = Cliente.cad_nome;

        Console.WriteLine(OSInputModel);
    }



    public async Task GoToUpdate(OrdensServicosItens Item)
    {
        try
        {

            var parameters = new DialogParameters<ConfirmQtdeAndDescriptionDialog>
            {
                { x => x.ContentTextTitle, $"{Item.Produto.pro_codigo} - {Item.ordserite_nome}?" },
                { x => x.ProductDescription, Item.ordserite_nome},

                { x => x._ProductServiceValue, Item.ordserite_valorunitario},
                { x => x._ProductServiceDiscount, Item.ordserite_desconto},

                { x => x.ButtonText, "Sim" },
                { x => x.Color, Color.Success }
            };

            var opt = new DialogOptions
            {
                CloseOnEscapeKey = true,
                FullWidth = true,
                FullScreen = IsMobile
            };

            var dialog = await DialogService.ShowAsync<ConfirmQtdeAndDescriptionDialog>("Editar Item O.S.", parameters, opt);
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                Snackbar.Add("Produto Atualizado", Severity.Success);

                var resultRetorn = (AddItemWithQtyInputModel)result.Data;

                if (resultRetorn == null)
                    return;

                var itemAdd = new EditItemWithQtyInputModel()
                {
                    OSItens = Item,
                    ProductServiceValue = resultRetorn.ProductServiceValue,
                    ProductServiceDiscount = resultRetorn.ProductServiceDiscount,
                    Qtde = resultRetorn.Qtde,
                    ProductName = resultRetorn.ProductDescription?.ToUpper(),
                };


                var input = new OrdensServicosItensInputModel();

                input._ordserite_ordser_key = OSInputModel._ordser_key;
                input._item = Item.ordserite_item;
                input._ordserite_pro_codigo = Item.ordserite_pro_codigo;
                input._ordserite_valorunitario = itemAdd.ProductServiceValue ?? 0;

                input._ordserite_desconto = itemAdd.ProductServiceDiscount ?? 0;
                input._ordserite_subtotal = decimal.Subtract(input._ordserite_valorunitario, itemAdd.ProductServiceDiscount ?? 0);

                input._ordserite_qtd = itemAdd.Qtde;

                input._ordserite_total = decimal.Multiply(itemAdd.Qtde, input._ordserite_subtotal);

                input._ordserite_nome = itemAdd.ProductName;

                input._ordserite_fun_key = OSInputModel.Funcionario != null ? OSInputModel.Funcionario.fun_key : 0;
                input._usu = 0;
                input._comput = Environment.MachineName;
                input._custo = 0;
                input._pro_nome = Item.Produto.pro_nome;
                input._emp_key = ServiceLocal.EmpresaAtual.emp_key;
                input._justificativa = string.Empty;
                input._ordserite_lote = null;
                input._ordserite_datafab = null;
                input._ordserite_dataval = null;


                var resultOSItemService = await UowAPI.OrdemServicoItemService.GravarAsync(input);

                if (resultOSItemService.IsSuccess)
                {
                    await UpdateOSInMemoryAsync((int)OSInputModel._ordser_key);
                }
                else
                {
                    HandleError(resultOSItemService.Errors);
                }
            }
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    //CONTINUAR TESTANDO A EXCLUSÃO DE ITENS DO PEDIDO
    public async Task DeleteAsync(OrdensServicosItens item)
    {
        try
        {
            var resultDialog = await ConfirmationDialogService.ConfirmAsync("Confirmar Exclusão", $"Confirma exclusão do item {item.ordserite_nome}?");

            if (resultDialog)
            {
                await UowAPI.OrdemServicoItemService.DeleteAsync(item);
                await UpdateOSInMemoryAsync(OSInputModel.CurrentOS.ordser_key);
            }
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    public async void FinishOS()
    {
        try
        {
            if (!OSInputModel.DimissEdit)
            {
                if (OSInputModel.CanFinish)
                {
                    await SaveOSAsync();
                    Snackbar.Add("O.S. liberado para o caixa", Severity.Success);
                    Navigation.NavigateTo("/ordem-servico");
                }
                else
                {
                    var msg = new List<string>
                    {
                        "A OS não pode ser finalizado",
                        "Verifique se existem itens no pedido",
                        "Verifique se não existe saldo para informar formas de pagamento",
                    };
                    HandleMessageWithDetails("Atenção", msg);
                }
            }
            else
            {
                if (OSInputModel.CanFinish)
                {
                    await UpdateOSInMemoryAsync(OSInputModel.CurrentOS.ordser_key);
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




    public async Task SearchProductsDialogAsync()
    {
        try
        {
            await SaveOSAsync();
            await AddNewProductInOSAsync();
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    private async Task UpdateOSInMemoryAsync(int ordSerKey)
    {
        var dadosOS = await UowAPI.OrdemServicoService.GetByOrdSerKeyAsync(emp_key, ordSerKey);
        OSInputModel.CurrentOS = dadosOS.Items.FirstOrDefault();

        OSInputModel._ordser_key = OSInputModel.CurrentOS.ordser_key;
        OSInputModel._ordser_obs = OSInputModel.CurrentOS.ordser_obs;
        OSInputModel._ordser_numero = OSInputModel.CurrentOS.ordser_numero;
        OSInputModel.Funcionario = OSInputModel.CurrentOS.Funcionario;
        OSInputModel.Cliente = OSInputModel.CurrentOS.Cliente;

        await InvokeAsync(StateHasChanged);
    }

    private async Task<Result<OrdensServicoGravarRetornoFuncao>> GravarOSServiceAsync()
    {
        OSInputModel._ordser_obs = OSInputModel.CurrentOS.ordser_obs;
        OSInputModel._ordser_nome = OSInputModel.Cliente.cad_nome;
        OSInputModel._ordser_cad_key = OSInputModel.Cliente.cad_key;
        OSInputModel._ordser_fun_key = OSInputModel.Funcionario?.fun_key != 0 ? OSInputModel.Funcionario?.fun_key : null;

        return await UowAPI.OrdemServicoService.GravarAsync(OSInputModel);
    }

    private async Task AddNewProductInOSAsync()
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

        var dialog = await DialogService.ShowAsync<SearchProductDialogWithUpdateData>("Adicionar Produtos", parameters, _options);
        return await dialog.Result;
    }

    private async Task AddProductAsync(AddItemWithQtyInputModel inputItem)
    {
        var input = new OrdensServicosItensInputModel();

        input._ordserite_ordser_key = OSInputModel._ordser_key;
        input._item = 0;

        input._ordserite_pro_codigo = inputItem.ProdutosEmpresas.Produto.pro_codigo;
        input._ordserite_valorunitario = inputItem.ProdutosEmpresas.proemp_valor;

        input._ordserite_desconto = inputItem.ProductServiceDiscount ?? 0;
        input._ordserite_subtotal = decimal.Subtract(input._ordserite_valorunitario, input._ordserite_desconto);

        input._ordserite_qtd = inputItem.Qtde;

        input._ordserite_total = decimal.Multiply(inputItem.Qtde, input._ordserite_subtotal);

        input._ordserite_nome = inputItem.ProductDescription;

        input._ordserite_fun_key = OSInputModel.Funcionario != null ? OSInputModel.Funcionario.fun_key : 0;
        input._usu = 0;
        input._comput = Environment.MachineName;
        input._custo = 0;
        input._pro_nome = inputItem.ProdutosEmpresas.Produto.pro_nome;
        input._emp_key = ServiceLocal.EmpresaAtual.emp_key;
        input._justificativa = string.Empty;
        input._ordserite_lote = inputItem.ProdutosEmpresas.proemp_lote;
        input._ordserite_datafab = null;
        input._ordserite_dataval = null;


        var resultOSItemService = await UowAPI.OrdemServicoItemService.GravarAsync(input);

        if (resultOSItemService.IsSuccess)
        {
            await UpdateOSInMemoryAsync((int)OSInputModel._ordser_key);
        }
        else
        {
            HandleError(resultOSItemService.Errors);
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
        await SaveOSAsync();

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

    private async Task SaveOSAsync()
    {
        try
        {
            if (OSInputModel.CurrentOS.ordser_finalizado == 1)
                return;

            var result = await GravarOSServiceAsync();
            if (!result.IsSuccess)
                HandleError(result.Errors);

            OSInputModel._ordser_numero = result.Data._ordser_numero;
            OSInputModel._ordser_key = result.Data._ordser_key;

            await UpdateOSInMemoryAsync(result.Data._ordser_key);


        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }
}
