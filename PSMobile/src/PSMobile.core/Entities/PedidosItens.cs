using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("pedidositens")]
public class PedidosItens : BaseEntity
{
    [Key]
    public int pedite_key { get; set; }
    public int pedite_item { get; set; }
    public string pedite_pro_codigo { get; set; }
    public decimal pedite_valorunitario { get; set; }
    public decimal pedite_desconto { get; set; }
    public decimal pedite_subtotal { get; set; }
    public decimal pedite_qtd { get; set; }
    public decimal pedite_total { get; set; }
    public int pedite_ped_key { get; set; }
    public short pedite_exc { get; set; }
    public string? pedite_nome { get; set; }
    public short pedite_lancado { get; set; }
    public short pedite_servico { get; set; }
    public int? pedite_fun_key { get; set; }
    public int? pedite_emp_key { get; set; }
    public string? pedite_id { get; set; }
    public string? pedite_lote { get; set; }
    public DateTime? pedite_datafab { get; set; }
    public DateTime? pedite_dataval { get; set; }
    public int? pedite_estoque_emp_key { get; set; }

    public Pedidos Pedido { get; set; } = null!;
    public Produtos Produto { get; set; } = null!;
    public string IsTipo => pedite_servico == 1 ? "Serviço" : "Produto";

    public override void Deletar()
    {
        this.pedite_exc = 1;
    }
    public override void ReAtivar()
    {
        this.pedite_exc = 0;
    }
}
