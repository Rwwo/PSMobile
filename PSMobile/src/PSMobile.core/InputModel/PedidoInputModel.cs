using PSMobile.core.Entities;

namespace PSMobile.core.InputModel;

public class PedidoInputModel : PSMobile.core.Entities.InputModel
{
    public PedidoInputModel() { }
    public PedidoInputModel(int ped_emp_key)
    {
        _ped_emp_key = ped_emp_key;
    }

    public Cadastros Cliente { get; set; } = new();
    public Funcionarios Funcionario { get; set; } = new();
    public Pedidos? CurrentPedido { get; set; } = new();


    public int? _ped_key { get; set; } = null;
    public int _ped_numero { get; set; }
    public int _ped_emp_key { get; set; }
    public int? _ped_cad_key => Cliente.cad_key != 0 ? Cliente.cad_key : null;
    public string _ped_comput { get; set; } = "API PSMobile";
    public int _ped_usu { get; set; } = 0;
    public int? _ped_fun_key => Funcionario.fun_key != 0 ? Funcionario.fun_key : null;
    public string _ped_obs { get; set; } = "";
    public string _ped_nome => Cliente.cad_key != 0 ? Cliente.cad_nome : "(SEM CLIENTE DEFINIDO...)";
    public decimal _ped_frete { get; set; } = 0;
    public int _ped_tabelacusto { get; set; } = 0;
    public DateTime? _ped_dataent { get; set; } = null;


}
