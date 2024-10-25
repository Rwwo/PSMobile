using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PSMobile.core.Entities;

[Table("ordensservicos")]
public class OrdensServicos : Entity
{
    [Key]
    public int ordser_key { get; set; }
    public int ordser_numero { get; set; }
    public string? ordser_nome { get; set; }
    public int ordser_emp_key { get; set; }
    public int? ordser_cad_key { get; set; }
    public DateTime? ordser_data { get; set; }
    public string? ordser_comput { get; set; }
    public int? ordser_usu { get; set; }
    public int? ordser_fun_key { get; set; }
    public decimal? ordser_total { get; set; }
    public short ordser_finalizado { get; set; }
    public short ordser_exc { get; set; }
    public int? ordser_mov_key { get; set; }
    public short ordser_lancado { get; set; }
    public string? ordser_obs { get; set; }
    public string? ordser_fone { get; set; }
    public string? ordser_contato { get; set; }
    public string? ordser_endereco { get; set; }
    public string? ordser_placa { get; set; }
    public DateTime? ordser_datalan { get; set; }
    public string? ordser_faturamento { get; set; }
    public DateTime? ordser_dataimp { get; set; }
    public short ordser_arquivado { get; set; }
    public string? ordser_cnpj { get; set; }
    public decimal? ordser_sinal { get; set; }
    public DateTime? ordser_datapre { get; set; }
    public DateTime? ordser_dataenv { get; set; }
    public DateTime? ordser_dataret { get; set; }
    public DateTime? ordser_dataent { get; set; }
    public short ordser_index { get; set; }
    public int? ordser_vei_key { get; set; }
    public short ordser_sincenviar { get; set; }
    public string? ordser_id { get; set; }
    public string? ordser_anotacoes { get; set; }
    public int? ordser_staordser_key { get; set; }
    public short ordser_tipoos { get; set; }
    public DateTime? ordser_dataval { get; set; }
    public decimal? ordser_descontoprodutos { get; set; }
    public decimal? ordser_descontoservicos { get; set; }
    public int? ordser_cad_key_terceiro { get; set; }
    public short ordser_tabelacusto { get; set; }
    public short ordser_faturarsomenteservico { get; set; }

    public bool IsOpen => ordser_lancado == 0 && ordser_exc == 0 && ordser_finalizado == 0;
    public bool IsFatured => ordser_lancado == 1 && ordser_exc == 0;
    public bool IsDeleted => ordser_exc == 1;
    public bool IsFinished => ordser_finalizado == 1 && ordser_lancado == 0 && ordser_exc == 0;


    public Empresas? Empresa { get; set; } = null;
    public Funcionarios? Funcionario { get; set; } = null;
    public Cadastros? Cliente { get; set; } = null;

    public ICollection<OrdensServicosItens>? OrdensServicosItens { get; set; } = new List<OrdensServicosItens>();

}


