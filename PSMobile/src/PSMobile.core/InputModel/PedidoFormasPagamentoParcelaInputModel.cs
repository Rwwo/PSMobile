using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.InputModel;

public class PedidoFormasPagamentoParcelaInputModel : PSMobile.core.Entities.InputModel
{
    [Required]
    public int pedforpagpar_parcela { get; set; }
    
    [Required]
    public int pedforpagpar_parcelas { get; set; }

    [Required]
    public DateTime pedforpagpar_dataven { get; set; }

    [Required]
    public decimal pedforpagpar_valor { get; set; }

    [Required]
    public string pedforpagpar_titulo { get; set; }

    [Required]
    public int pedforpagpar_pedforpag_key { get; set; }

    [Required]
    public int pedforpagpar_forpag_codigo { get; set; }

}
