using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("produtosempresas")]
public class ProdutosEmpresas : Entity
{
    [Key]
    public int proemp_key { get; set; }
    public int proemp_pro_key { get; set; }
    public int proemp_emp_key { get; set; }
    public decimal? proemp_custo { get; set; }
    public decimal? proemp_customedio { get; set; }
    public decimal? proemp_margem { get; set; }
    public decimal proemp_valor { get; set; }
    public decimal? proemp_qtd { get; set; }
    public DateTime? proemp_dataultcompra { get; set; }
    public DateTime? proemp_dataultvenda { get; set; }
    public short proemp_desconto { get; set; }
    public decimal? proemp_descontopadrao { get; set; }
    public decimal? proemp_descontomax { get; set; }
    public decimal? proemp_qtdmin { get; set; }
    public decimal? proemp_qtdmax { get; set; }
    public string? proemp_obs { get; set; }
    public string? proemp_local { get; set; }
    public decimal? proemp_fator { get; set; }
    public short proemp_promocao { get; set; }
    public short proemp_promocaotipo { get; set; }
    public DateTime? proemp_promocaododia { get; set; }
    public DateTime? proemp_promocaoaodia { get; set; }
    public decimal? proemp_promocaovalor { get; set; }
    public decimal? proemp_promocaoparacada { get; set; }
    public string? proemp_promocaocodigo { get; set; }
    public DateTime proemp_datacad { get; set; }
    public short proemp_exc { get; set; }
    public DateTime? proemp_dataexc { get; set; }
    public DateTime? proemp_datamud { get; set; }
    public int? proemp_usu { get; set; }
    public string? proemp_comput { get; set; }
    public decimal? proemp_custoreal { get; set; }
    public short proemp_enviarcarga { get; set; }
    public decimal? proemp_margempadrao { get; set; }
    public short proemp_piscofinstipo { get; set; }
    public int? proemp_piscofinscstentradas { get; set; }
    public int? proemp_piscofinsvinculo { get; set; }
    public int? proemp_piscofinsbase { get; set; }
    public int? proemp_piscofinscstsaidas { get; set; }
    public int? proemp_piscofinsnatureza { get; set; }
    public string? proemp_cst { get; set; }
    public string? proemp_cfop { get; set; }
    public short proemp_liberado { get; set; }
    public decimal? proemp_qtdconsignado { get; set; }
    public decimal? proemp_qtdemterceiros { get; set; }
    public decimal? proemp_custobrutonotacompra { get; set; }
    public decimal? proemp_descontonotacompra { get; set; }
    public decimal? proemp_qtd_reservado { get; set; }
    public decimal? proemp_qtdconsignado_reservado { get; set; }
    public short proemp_vendarapida { get; set; }
    public decimal? proemp_qtdindustrializacao { get; set; }
    public short proemp_listapiscofins { get; set; }
    public string? proemp_lote { get; set; }
    public decimal? proemp_custofixo { get; set; }
    public string? proemp_sinc { get; set; }
    public short proemp_sincenviar { get; set; }
    public decimal? proemp_valoratacado { get; set; }
    public string? proemp_cfopentrada { get; set; }
    public short proemp_destinacao { get; set; }
    public decimal? proemp_qtd_pausado { get; set; }
    public decimal? proemp_customediosemicms { get; set; }
    public int? proemp_atividadeservico { get; set; }
    public DateTime? proemp_dataval { get; set; }
    public short proemp_servicorecibo { get; set; }
    public decimal? proemp_redbaseissqnprodutos { get; set; }


    public Produtos Produto { get; set; } = null!;
}
