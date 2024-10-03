using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.InputModel;

public class PedidoFormasPagamentoInputModel : PSMobile.core.Entities.InputModel
{
    [Required]
    public int pedforpag_ped_key { get; set; }

    [Required]
    public int pedforpag_forpag_codigo { get; set; }

    [Required]
    public decimal pedforpag_valor { get; set; }

    public List<PedidoFormasPagamentoParcelaInputModel> ParcelasInputModel { get; set; }
}
