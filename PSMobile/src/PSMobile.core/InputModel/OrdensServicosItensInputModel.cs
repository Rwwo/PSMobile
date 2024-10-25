namespace PSMobile.core.InputModel;

public class OrdensServicosItensInputModel : PSMobile.core.Entities.InputModel
{
    public int _ordserite_ordser_key { get; set; }
    public int _item { get; set; }
    public string _ordserite_pro_codigo { get; set; }
    public decimal _ordserite_valorunitario { get; set; }
    public decimal _ordserite_desconto { get; set; }
    public decimal _ordserite_subtotal { get; set; }
    public decimal _ordserite_qtd { get; set; }
    public decimal _ordserite_total { get; set; }
    public string _ordserite_nome { get; set; }
    public int? _ordserite_fun_key { get; set; }
    public int _usu { get; set; }
    public string _comput { get; set; }
    public decimal _custo { get; set; }
    public string _pro_nome { get; set; }
    public int _emp_key { get; set; }
    public string _justificativa { get; set; }
    public string? _ordserite_lote { get; set; }
    public DateTime? _ordserite_datafab { get; set; }
    public DateTime? _ordserite_dataval { get; set; }

}
