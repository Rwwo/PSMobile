using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class Prescritores : Entity
{
    [Key]
    public int pre_key { get; set; }
    public int? pre_crm { get; set; }
    public string? pre_fone { get; set; }
    public string? pre_nome { get; set; }
    public string? pre_ufcrm { get; set; }
    public short pre_exc { get; set; }
    public DateTime? pre_datacad { get; set; }
    public int? pre_pretit_key { get; set; }
    public string? pre_endereco { get; set; }
    public string? pre_bairro { get; set; }
    public int? pre_cid_codigo { get; set; }
    public int? pre_ufs_codigo { get; set; }
    public string? pre_cep { get; set; }
    public string? pre_celular { get; set; }
    public string? pre_email { get; set; }
    public string? pre_obs { get; set; }
    public DateTime? pre_datamud { get; set; }
    public int? pre_usu { get; set; }
    public string? pre_comput { get; set; }
    public int? pre_con_key { get; set; }
    public string? pre_sinc { get; set; }
    public short pre_sincenviar { get; set; }
    public int? pre_numero { get; set; }
    public string? pre_complemento { get; set; }
    public DateTime? pre_dataexc { get; set; }
    public int pre_tmpconsul { get; set; }

    public override string ToString() => pre_nome;
}