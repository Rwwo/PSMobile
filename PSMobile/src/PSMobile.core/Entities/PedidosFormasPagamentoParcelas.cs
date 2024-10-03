using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("pedidosformaspagamentoparcelas")]
public class PedidosFormasPagamentoParcelas : Entity
{
    [Key]
    public int pedforpagpar_key { get; set; }
    public int pedforpagpar_parcela { get; set; }
    public int pedforpagpar_parcelas { get; set; }
    public DateTime pedforpagpar_dataven { get; set; }
    public decimal pedforpagpar_valor { get; set; }
    public string pedforpagpar_titulo { get; set; } = null!;
    public int pedforpagpar_pedforpag_key { get; set; }
    public int pedforpagpar_forpag_codigo { get; set; }
    
    public PedidosFormasPagamento? PedidosFormasPagamento { get; set; } = null;

}