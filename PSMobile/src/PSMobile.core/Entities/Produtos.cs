using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("produtos")]
public class Produtos : Entity
{
    [Key]
    public int pro_key { get; set; }
    public string pro_codigo { get; set; }
    public string? pro_reduzido { get; set; }
    public short pro_categoria { get; set; }
    public decimal? pro_peso { get; set; }
    public int pro_ali_key { get; set; }
    public int pro_uni_key { get; set; }
    public int? pro_gru1_codigo { get; set; }
    public int? pro_gru2_codigo { get; set; }
    public int? pro_gru3_codigo { get; set; }
    public decimal? pro_redbasecalculo { get; set; }
    public int? pro_validade { get; set; }
    public string? pro_ncms { get; set; }
    public decimal? pro_mva { get; set; }
    public decimal? pro_ipi { get; set; }
    public string pro_nome { get; set; }
    public string pro_nomeecf { get; set; }
    public string? pro_codigobaixaestoque { get; set; }
    public DateTime? pro_datacad { get; set; }
    public short pro_exc { get; set; }
    public DateTime? pro_dataexc { get; set; }
    public DateTime? pro_datamud { get; set; }
    public int? pro_usu { get; set; }
    public string? pro_comput { get; set; }
    public string? pro_complemento { get; set; }
    public int? pro_cad_for_key { get; set; }
    public decimal? pro_icmsproprio { get; set; }
    public short pro_imagem { get; set; }
    public int? pro_fablab_key { get; set; }
    public string? pro_registroms { get; set; }
    public short pro_controlado { get; set; }
    public decimal? pro_medida1 { get; set; }
    public decimal? pro_medida2 { get; set; }
    public decimal? pro_medida3 { get; set; }
    public string? pro_utilizacao { get; set; }
    public short pro_cozinha { get; set; }
    public int? pro_demarcador { get; set; }
    public string? pro_lcc { get; set; }
    public short pro_copa { get; set; }
    public short pro_cozinha2 { get; set; }
    public short pro_porcaoextra { get; set; }
    public int? pro_sabores { get; set; }
    public short pro_cozinha3 { get; set; }
    public short pro_exigecomplemento { get; set; }
    public string? pro_sinc { get; set; }
    public short pro_popular { get; set; }
    public decimal? pro_qtdporcaixa { get; set; }
    public short pro_continuo { get; set; }
    public short pro_anp { get; set; }
    public string? pro_anp_codigo { get; set; }
    public string? pro_aviso { get; set; }
    public string? pro_cest { get; set; }
    public short pro_digitacao { get; set; }
    public int? pro_uni_key_tributada { get; set; }
    public decimal? pro_qtd_tributada { get; set; }
    public decimal? pro_glp { get; set; }
    public decimal? pro_gnn { get; set; }
    public decimal? pro_gni { get; set; }
    public short pro_delivery { get; set; }
    public decimal? pro_fcp { get; set; }
    public string? pro_gia52_codigo { get; set; }
    public int? pro_cat_key { get; set; }
    public string? pro_ean { get; set; }
    public decimal? pro_litros { get; set; }
    public short pro_reterirrf { get; set; }
    public short pro_retercsll { get; set; }
    public short pro_reterpis { get; set; }
    public short pro_retercofins { get; set; }
    public short pro_reterprevidenciasocial { get; set; }
    public short pro_pedirobs { get; set; }
    public string? pro_imagem1 { get; set; }
    public string? pro_imagem2 { get; set; }
    public string? pro_imagem3 { get; set; }
    public string? pro_imagem4 { get; set; }
    public string? pro_imagem5 { get; set; }
    public decimal? pro_fracao { get; set; }
    public string? pro_sku { get; set; }
    public int? pro_basleg_key { get; set; }
    public string? pro_nomesite { get; set; }
    public short pro_monitorar { get; set; }
    public string? pro_nbs { get; set; }
    public int? pro_cnae { get; set; }
    public short pro_est_key { get; set; }
    public short pro_cor_key { get; set; }
    public int? pro_col_key { get; set; }
    public short pro_ecommerce { get; set; }

    public ProdutosEmpresas ProdutosEmpresas { get; set; } = null!;

}