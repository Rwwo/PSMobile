using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("empresas")]
public class Empresas : Entity
{
    [Key]
    public int emp_key { get; set; }
    public string? emp_cnpj { get; set; }
    public string? emp_nome { get; set; }
    public string? emp_razao { get; set; }
    public string? emp_ie { get; set; }
    public string? emp_im { get; set; }
    public string? emp_cep { get; set; }
    public int emp_numero { get; set; }
    public string? emp_complemento { get; set; }
    public int? emp_ufs_codigo { get; set; }
    public int? emp_cid_codigo { get; set; }
    public short emp_regime { get; set; }
    public string? emp_chave { get; set; }
    public string? emp_responsavel { get; set; }
    public string? emp_foneresponsavel { get; set; }
    public string? emp_email { get; set; }
    public string? emp_site { get; set; }
    public short emp_tipo { get; set; }
    public short emp_atividade { get; set; }
    public short emp_flag { get; set; }
    public DateTime? emp_datafla { get; set; }
    public short emp_exc { get; set; }
    public DateTime? emp_dataexc { get; set; }
    public int? emp_usu { get; set; }
    public string? emp_comput { get; set; }
    public string? emp_apelido { get; set; }
    public string? emp_suframa { get; set; }
    public short emp_tipospeed { get; set; }
    public decimal? emp_custooperacional { get; set; }
    public string? emp_endereco { get; set; }
    public string? emp_bairro { get; set; }
    public DateTime? emp_dataultsin { get; set; }
    public int? emp_nfeserie { get; set; }
    public int? emp_nfeinicial { get; set; }
    public string? emp_ip { get; set; }
    public short emp_tipoimpnfe { get; set; }
    public short emp_ambientenfe { get; set; }
    public byte[] emp_logonfe { get; set; }
    public string? emp_smtp { get; set; }
    public int? emp_porta { get; set; }
    public string? emp_login { get; set; }
    public string? emp_senha { get; set; }
    public short emp_usarssl { get; set; }
    public short emp_usarcredenciaispadrao { get; set; }
    public string? emp_ipporta { get; set; }
    public short emp_qrcode { get; set; }
    public string? emp_qrcodecsc { get; set; }
    public int? emp_qrcodesequencial { get; set; }
    public string? emp_tef_ipservidor { get; set; }
    public int? emp_tef_portaservidor { get; set; }
    public int? emp_tef_codigoestabelecimento { get; set; }
    public int? emp_tef_codigoloja { get; set; }
    public string? emp_sinc { get; set; }
    public string? emp_datasus_usuario { get; set; }
    public string? emp_datasus_senha { get; set; }
    public int? emp_cteserie { get; set; }
    public int? emp_cteinicial { get; set; }
    public string? emp_antt { get; set; }
    public string? emp_aut_chave { get; set; }
    public string? emp_aut_endereco { get; set; }
    public string? emp_aut_login { get; set; }
    public string? emp_aut_senha { get; set; }
    public string? emp_aut_cnpj { get; set; }
    public short emp_modonotaservico { get; set; }
    public short emp_nfsmultiempresa { get; set; }
    public string? emp_codigoconta { get; set; }
    public short emp_permitecreditosn { get; set; }
    public string? emp_smtp_pedidos { get; set; }
    public int? emp_porta_pedidos { get; set; }
    public string? emp_login_pedidos { get; set; }
    public string? emp_senha_pedidos { get; set; }
    public short emp_usarssl_pedidos { get; set; }
    public short emp_usarcredenciaispadrao_pedidos { get; set; }
    public string? emp_smtp_os { get; set; }
    public int? emp_porta_os { get; set; }
    public string? emp_login_os { get; set; }
    public string? emp_senha_os { get; set; }
    public short emp_usarssl_os { get; set; }
    public short emp_usarcredenciaispadrao_os { get; set; }
    public string? emp_smtp_orcamentos { get; set; }
    public int? emp_porta_orcamentos { get; set; }
    public string? emp_login_orcamentos { get; set; }
    public string? emp_senha_orcamentos { get; set; }
    public short emp_usarssl_orcamentos { get; set; }
    public short emp_usarcredenciaispadrao_orcamentos { get; set; }
    public short emp_regimefederal { get; set; }
    public int? emp_mdfeserie { get; set; }
    public int? emp_mdfeinicial { get; set; }
    public int? emp_tefplug_empresa { get; set; }
    public int? emp_tefplug_filial { get; set; }
    public int? emp_nfce5949serie { get; set; }
    public int? emp_nfce5949inicial { get; set; }
}
