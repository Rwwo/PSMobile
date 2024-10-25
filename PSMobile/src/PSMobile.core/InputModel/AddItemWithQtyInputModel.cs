using PSMobile.core.Entities;

namespace PSMobile.core.InputModel;

public class AddItemWithQtyInputModel : PSMobile.core.Entities.InputModel
{

    public ProdutosEmpresas ProdutosEmpresas { get; set; }
    public string? ProductDescription { get; set; }
    public decimal? ProductServiceValue { get; set; } = null;
    public decimal? ProductServiceDiscount { get; set; } = null;
    public int Qtde { get; set; }
}
