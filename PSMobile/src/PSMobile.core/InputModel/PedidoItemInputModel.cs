namespace PSMobile.core.InputModel;

public class PedidoItemInputModel : PSMobile.core.Entities.InputModel
{
    public int _pedite_ped_key { get; set; }
    public int _item { get; set; }
    public string _pedite_pro_codigo { get; set; } = null!;
    public decimal _pedite_valorunitario { get; set; } = 0;
    public decimal _pedite_desconto { get; set; } = 0;
    public decimal _pedite_subtotal { get; set; } = 0;
    public decimal _pedite_qtd { get; set; } = 0;
    public decimal _pedite_total { get; set; } = 0;
    public string _pedite_nome { get; set; } = null!;
    public int? _pedite_fun_key { get; set; }
    public int _usu { get; set; } = 0;
    public string _comput { get; set; } = "PS";
    public decimal? _custo { get; set; } = 0;
    public string _pro_nome { get; set; } = null!;
    public int _emp_key { get; set; }
    public string _justificativa { get; set; } = string.Empty;
    public string? _pedite_lote { get; set; } = null;
    public DateTime? _pedite_datafab { get; set; } = null;
    public DateTime? _pedite_dataval { get; set; } = null;
}
