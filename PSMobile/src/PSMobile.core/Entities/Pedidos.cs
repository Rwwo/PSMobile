using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PSMobile.core.Enums;


namespace PSMobile.core.Entities;

[Table("pedidos")]
public class Pedidos : BaseEntity
{
    [Key]
    public int ped_key { get; set; }
    public int ped_numero { get; set; }
    public string? ped_nome { get; set; } 
    public int ped_emp_key { get; set; }
    public int? ped_cad_key { get; set; }
    public DateTime? ped_data { get; set; }
    public string ped_comput { get; set; } = string.Empty;
    public int ped_usu { get; set; } = 0;
    public int? ped_fun_key { get; set; } = null;
    public decimal? ped_total { get; set; }
    public short ped_finalizado { get; set; }
    public short ped_exc { get; set; }
    public int? ped_mov_key { get; set; }
    public short ped_lancado { get; set; }
    public string? ped_obs { get; set; } = string.Empty;
    public string? ped_fone { get; set; } = string.Empty;
    public string? ped_contato { get; set; }
    public string? ped_endereco { get; set; }
    public DateTime? ped_datalan { get; set; }
    public string? ped_val_key_array { get; set; }
    public decimal? ped_desconto { get; set; }
    public int? ped_recpop_key { get; set; }
    public string? ped_prepag_key_array { get; set; }
    public int? ped_crm { get; set; }
    public DateTime? ped_dataexc { get; set; }
    public DateTime? ped_dataimp { get; set; }
    public decimal ped_frete { get; set; } = 0;
    public short ped_vinculado { get; set; }
    public TipoRetirada ped_retira { get; set; }
    public TipoVenda ped_iddest { get; set; }
    public TipoDoc ped_tipodocemitir { get; set; }
    public short ped_consumidorfinal { get; set; }
    public short ped_tabelacusto { get; set; } = 0;
    public decimal? ped_acrescimo { get; set; }
    public int? ped_cad_key_pontos { get; set; }
    public DateTime? ped_dataent { get; set; }
    public int? ped_usu_criacao { get; set; }
    public DateTime? ped_datafin { get; set; }
    public decimal? ped_valoripi { get; set; }

    public Funcionarios? Funcionario { get; set; } = new();
    public Cadastros? Cliente { get; set; } = new();
    public ICollection<PedidosItens>? PedidosItens { get; set; } = new List<PedidosItens>();
    public ICollection<PedidosFormasPagamento>? PedidosFormasPagamento { get; set; } = new List<PedidosFormasPagamento>();


    public bool IsOpen => ped_lancado == 0 && ped_exc == 0 && ped_finalizado == 0;
    public bool IsFatured => ped_lancado == 1 && ped_exc == 0;
    public bool IsDeleted => ped_exc == 1;
    public bool IsFinished => ped_finalizado == 1 && ped_lancado == 0 && ped_exc == 0;


    public override void Deletar()
    {
        ped_exc = 1;
        ped_dataexc = DateTime.Now;
    }
    public override void ReAtivar()
    {
        ped_exc = 0;
        ped_dataexc = null;
    }
}


