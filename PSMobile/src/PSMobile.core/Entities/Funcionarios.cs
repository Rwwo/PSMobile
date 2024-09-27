using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("funcionarios")]
public class Funcionarios : BaseEntity
{
    [Key]
    public int fun_key { get; set; }
    public short? fun_tipoven { get; set; }
    public string? fun_cpf { get; set; } = null;
    public string? fun_sexo { get; set; } = null;
    public string? fun_nome { get; set; } =null;
    public string? fun_email { get; set; } = null;
    public string? fun_rg { get; set; } = null;
    public string? fun_orgao { get; set; } = null;
    public DateTime? fun_datanas { get; set; } = null;
    public string? fun_obs { get; set; } = null;
    public string? fun_cargo { get; set; } = null;
    public DateTime? fun_dataadm { get; set; } = null;
    public string? fun_carteira { get; set; } = null;
    public string? fun_cep { get; set; } = null;
    public int? fun_numero { get; set; } = null;
    public string? fun_complemento { get; set; } = null;
    public int? fun_cid_codigo { get; set; } = null;
    public int? fun_ufs_codigo { get; set; } = null;
    public short? fun_tipocai { get; set; } = null;
    public string? fun_apelido { get; set; } = null;
    public decimal? fun_ven_comissao { get; set; } = null;
    public short? fun_ven_tipocom { get; set; } = null;
    public short? fun_exc { get; set; } = null;
    public DateTime? fun_dataexc { get; set; } = null;
    public int? fun_usu { get; set; } = null;
    public string? fun_comput { get; set; } = null;
    public DateTime? fun_datamud { get; set; } = null;
    public string? fun_senhacaixa { get; set; } = null;
    public short? fun_tiposup { get; set; } = null;
    public string? fun_senhasupervisor { get; set; } = null;
    public string? fun_endereco { get; set; } = null;
    public string? fun_bairro { get; set; } = null;
    public short? fun_imagem { get; set; } = null;
    public string? fun_sinc { get; set; } = null;
    public string? fun_anvisa_senha { get; set; } = null;
    public short? fun_tipotele { get; set; } = null;
    public short? fun_enviarweb { get; set; } = null;
    public DateTime? fun_datadem { get; set; } = null;
    public decimal? fun_ven_comissao_captacao { get; set; } = null;
    public decimal? fun_ven_comissao_prazo { get; set; } = null;
    public decimal? fun_comissaoparceiro { get; set; } = null;


    public ICollection<Pedidos>? Pedidos { get; set; } = null;

    public override string ToString()
    {
        return $"{fun_nome}";
    }

    public override void Deletar()
    {
        this.fun_exc = 1;
        this.fun_dataexc = DateTime.Now;
    }
    public override void ReAtivar()
    {
        this.fun_exc = 0;
        this.fun_dataexc = null;
    }

}
