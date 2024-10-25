using PSMobile.core.Entities;

namespace PSMobile.core.InputModel;

public class EditItemWithQtyInputModel : PSMobile.core.Entities.InputModel
{
    public PedidosItens PedidosItens { get; set; }
    public OrdensServicosItens OSItens { get; set; }
    public int Qtde { get; set; }
    public string? ProductName { get; set; }
    public decimal? ProductServiceValue { get; set; } = null;
    public decimal? ProductServiceDiscount { get; set; } = null;
}

