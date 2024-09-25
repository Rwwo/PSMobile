using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using MudExtensions;
using MudExtensions.Utilities;

using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common;
using PSMobile.SharedKernel.Common.Dtos;
using PSMobile.SharedKernel.Common.Dtos.Extensions;
using PSMobile.SharedUI.Components.Shared;

namespace PSMobile.SharedUI.Components.Pages.Pedido;

public class GravarPedidoPage : MyBaseComponent
{
    public PedidoInputModel InputModel { get; set; } = new();
    public Pedidos? CurrentPedido { get; set; } = new();

    
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
    public bool _showPreviousButton = true;
    public bool _showNextButton = true;
    public bool _showSkipButton = true;
    public bool _showStepResultIndicator = true;
    public bool _addResultStep = true;
    public bool _customLocalization = true;
    public Color _color = Color.Primary;
    public int _activeIndex = 0;
    public bool _loading;
    public bool _showCustomButton = false;
    public bool _vertical = false;
    public Size _headerSize = Size.Medium;
    public StepperActionsJustify _stepperActionsJustify = StepperActionsJustify.SpaceBetween;

    protected override async Task OnInitializedAsync()
    {

        var func = await UowAPI.FuncionariosService.GetAllAsync(1000, 1);
        InputModel.Funcionarios = func;

        CurrentPedido = ServiceLocal.Pedido;

        if (CurrentPedido is null)
            return;

        IsEditing = true;
        InputModel = CurrentPedido.ToPedidoInputModel();
        InputModel.Funcionarios = func;

        await InvokeAsync(StateHasChanged);
        await base.OnInitializedAsync();

    }

    public async Task ValidarNumeroDocumento()
    {
        var aux = InputModel.Cliente.cad_cnpj;

        if (!string.IsNullOrEmpty(InputModel.Cliente.cad_cnpj))
        {
            InputModel.Cliente.cad_cnpj = PSSysService.PSFormatarCNPJ(InputModel.Cliente.cad_cnpj);
            if (!string.IsNullOrEmpty(InputModel.Cliente.cad_cnpj))
            {
                InputModel.Cliente = await UowAPI.CadastroService.GetByDocNumberAsync(aux);
            }
        }
        else
        {
            InputModel.Cliente = new();
        }
    }
    public async Task SearchCustomer()
    {
        var parameters = new DialogParameters();

        var dialog = await DialogService.ShowAsync<SearchClientDialog>("Pesquisar Cliente", parameters);
        var result = await dialog.Result;

        if (!result.Canceled && result.Data is Cadastros clienteSelecionado)
            InputModel.Cliente = clienteSelecionado;

    }

    public async Task<IEnumerable<Funcionarios>> SearchEmployee(string value, CancellationToken token)
    {
        // In real life use an asynchronous function for fetching data from an api.
        await Task.Delay(5, token);

        // if text is null or empty, show complete list
        if (string.IsNullOrEmpty(value))
            return InputModel.Funcionarios.Items;

        return InputModel.Funcionarios.Items.Where(x => x.fun_nome.Contains(value, StringComparison.InvariantCultureIgnoreCase));
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

    public void StatusChanged(StepStatus status)
    {
        Snackbar.Add($"First step {status.ToDescriptionString()}.", Severity.Info);
    }
}
