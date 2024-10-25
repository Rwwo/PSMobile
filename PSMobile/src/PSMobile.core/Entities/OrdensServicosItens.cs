using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PSMobile.core.Entities;

[Table("ordensservicositens")]
public class OrdensServicosItens : Entity
{
    [Key]
    public int ordserite_key { get; set; }
    public int ordserite_item { get; set; }
    public string ordserite_pro_codigo { get; set; }
    public decimal ordserite_valorunitario { get; set; }
    public decimal ordserite_desconto { get; set; }
    public decimal ordserite_subtotal { get; set; }
    public decimal ordserite_qtd { get; set; }
    public decimal ordserite_total { get; set; }
    public int ordserite_ordser_key { get; set; }
    public short ordserite_exc { get; set; }
    public string? ordserite_nome { get; set; }
    public short ordserite_lancado { get; set; }
    public short ordserite_servico { get; set; }
    public int? ordserite_fun_key { get; set; }
    public int? ordserite_emp_key { get; set; }
    public string? ordserite_id { get; set; }
    public string? ordserite_lote { get; set; }
    public DateTime? ordserite_datafab { get; set; }
    public DateTime? ordserite_dataval { get; set; }
    public short ordserite_sincenviar { get; set; }
    public decimal? ordserite_valoricmsst { get; set; }
    public decimal ordserite_customedio { get; set; }
    public decimal? ordserite_valoripi { get; set; }

    public OrdensServicos OrdensServicos { get; set; } = null!;
    public Produtos? Produto { get; set; } = null;
}


