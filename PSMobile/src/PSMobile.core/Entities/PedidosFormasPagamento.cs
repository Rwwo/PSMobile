using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("pedidosformaspagamento")]
public class PedidosFormasPagamento : Entity
{
    [Key]
    public int pedforpag_key { get; set; }
    public int pedforpag_ped_key { get; set; }
    public int pedforpag_forpag_codigo { get; set; }
    public decimal pedforpag_valor { get; set; }
    public short pedforpag_lancado { get; set; }

    public FormasPagamento FormaPagamento { get; set; } = null!;
    public Pedidos Pedido { get; set; } = null!;
}