using PSMobile.core.Entities;

namespace PSMobile.core.InputModel;

public class AddItemWithQtyInputModel : PSMobile.core.Entities.InputModel
{
    public ProdutosEmpresas ProdutosEmpresas { get; set; }
    public int Qtde { get; set; }
}
