using PSMobile.core.Entities;

namespace PSMobile.core.InputModel;

public class EditItemWithQtyInputModel : PSMobile.core.Entities.InputModel
{
    public PedidosItens PedidosItens { get; set; }
    public int Qtde { get; set; }
}