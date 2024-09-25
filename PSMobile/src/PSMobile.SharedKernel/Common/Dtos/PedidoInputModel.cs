using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;

namespace PSMobile.SharedKernel.Common.Dtos;

public class PedidoInputModel
{
    public int ped_key { get; set; }
    public int ped_numero { get; set; }
    public string? ped_nome { get; set; }
    public int ped_emp_key { get; set; }
    public int? ped_cad_key { get; set; }
    public DateTime? ped_data { get; set; }
    public string? ped_comput { get; set; }
    public int? ped_usu { get; set; }
    public int? ped_fun_key { get; set; }
    public decimal? ped_total { get; set; }
    public short ped_finalizado { get; set; }
    public short ped_exc { get; set; }
    public int? ped_mov_key { get; set; }
    public short ped_lancado { get; set; }
    public string? ped_obs { get; set; }
    public string? ped_fone { get; set; }
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
    public decimal? ped_frete { get; set; }
    public short ped_vinculado { get; set; }
    public short ped_retira { get; set; }
    public short ped_iddest { get; set; }
    public short ped_tipodocemitir { get; set; }
    public short ped_consumidorfinal { get; set; }
    public short ped_tabelacusto { get; set; }
    public decimal? ped_acrescimo { get; set; }
    public int? ped_cad_key_pontos { get; set; }
    public DateTime? ped_dataent { get; set; }
    public int? ped_usu_criacao { get; set; }
    public DateTime? ped_datafin { get; set; }
    public decimal? ped_valoripi { get; set; }


    public List<PedidosFormasPagamento> PedidosFormasPagamento { get; set; } = new();
    public List<PedidosItens> PedidoItens { get; set; } = new();
    public Cadastros Cliente { get; set; } = new();
    public Funcionarios Funcionario { get; set; } = new();

    public PaginatedResult<Funcionarios> Funcionarios { get; set; }
    public List<Cadastros> Clientes { get; set; } = null!;

}