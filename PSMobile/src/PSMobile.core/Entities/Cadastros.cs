using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class Cadastros : BaseEntity
{
    [Key]
    public int cad_key { get; set; }

    public string? cad_razao { get; set; } = null;
    public short cad_tipocli { get; set; } = 0;
    public short cad_tipofor { get; set; } = 0;
    public short cad_tipotra { get; set; } = 0;
    public string? cad_ie { get; set; } = null;
    public string? cad_im { get; set; } = null;
    public string? cad_ist { get; set; } = null;
    public string? cad_cnpj { get; set; } = null;
    public string? cad_sexo { get; set; } = null;
    public string? cad_nome { get; set; } = null;
    public string? cad_obs { get; set; } = null;
    public string? cad_rg { get; set; } = null;
    public string? cad_orgao { get; set; } = null;
    public DateTime? cad_datanasfun { get; set; } = null;


    // Relacionamentos
    public CadastroCliente CadastroCliente { get; set; }
    public CadastroFornecedor CadastroFornecedor { get; set; }
    public CadastroTransportadora CadastroTransportadora { get; set; }
    public CadastroContato CadastroContato { get; set; }
    public CadastroEndereco CadastroEndereco { get; set; }
    public CadastroEndereco CadastroEnderecoEntrega { get; set; }
    public CadastroEndereco CadastroEnderecoCorrespondencia { get; set; }

    public override void Deletar()
    {
        CadastroCliente?.Deletar();
        CadastroFornecedor?.Deletar();
        CadastroTransportadora?.Deletar();
    }

    public override void ReAtivar()
    {
        CadastroCliente?.ReAtivar();
        CadastroFornecedor?.ReAtivar();
        CadastroTransportadora?.ReAtivar();
    }
}
public class CadastroCliente : BaseEntity
{
    public string? cad_cli_naturalidade { get; set; } = null;
    public short? cad_cli_exc { get; set; } = null;
    public DateTime? cad_cli_dataexc { get; set; } = null;
    public int cad_cli_usu { get; set; }
    public string? cad_cli_comput { get; set; } = "";
    public DateTime? cad_cli_datamud { get; set; } = null;
    public DateTime? cad_cli_datacad { get; set; } = null;
    public short? cad_cli_liberado { get; set; } = 1;
    public int? cad_cli_diastolerancia { get; set; } = null;
    public CadastroCredito CadastroCredito { get; set; }

    public override void Deletar()
    {
        cad_cli_exc = 1;
        cad_cli_dataexc = DateTime.Now;
        cad_cli_datamud = DateTime.Now;
    }
    public override void ReAtivar()
    {
        cad_cli_exc = null;
        cad_cli_dataexc = null;
        cad_cli_datamud = DateTime.Now;
    }
}

public class CadastroFornecedor : BaseEntity
{
    public string? cad_for_suframa { get; set; } = null;
    public int? cad_for_grufor_key { get; set; } = null;
    public short cad_for_creditoicms { get; set; } = 1;
    public short? cad_for_exc { get; set; } = null;
    public DateTime? cad_for_dataexc { get; set; } = null;
    public int cad_for_usu { get; set; }
    public string? cad_for_comput { get; set; } = "";
    public DateTime? cad_for_datamud { get; set; } = null;
    public DateTime? cad_for_datacad { get; set; } = null;
    public short cad_for_liberado { get; set; } = 1;
    public short cad_for_fornecedor { get; set; }
    public int cad_for_contacontabil { get; set; }
    public short cad_for_prestador { get; set; }

    public override void Deletar()
    {
        cad_for_exc = 1;
        cad_for_dataexc = DateTime.Now;
        cad_for_datamud = DateTime.Now;
    }

    public override void ReAtivar()
    {
        cad_for_exc = null;
        cad_for_dataexc = null;
        cad_for_datamud = DateTime.Now;
    }
}

public class CadastroTransportadora : BaseEntity
{
    public short? cad_tra_exc { get; set; }
    public DateTime? cad_tra_dataexc { get; set; }
    public int cad_tra_usu { get; set; }
    public string? cad_tra_comput { get; set; } = "";
    public DateTime? cad_tra_datamud { get; set; } = null;
    public DateTime? cad_tra_datacad { get; set; } = null;
    public string? cad_rntrc { get; set; } = null;
    public short cad_rntrctipoproprietario { get; set; } = -1;
    public short cad_tra_liberado { get; set; } = 1;

    public override void Deletar()
    {
        cad_tra_exc = 1;
        cad_tra_dataexc = DateTime.Now;
        cad_tra_datamud = DateTime.Now;
    }
    public override void ReAtivar()
    {
        cad_tra_exc = null;
    }
}

public class CadastroEndereco
{
    public int? cad_pai_codigo { get; set; } = 1058;
    public string? cad_cep { get; set; } = null;
    public int? cad_numero { get; set; } = null;
    public string? cad_complemento { get; set; } = null;
    public string? cad_endereco { get; set; } = null;
    public string? cad_bairro { get; set; } = null;
    public int? cad_ufs_codigo { get; set; } = 43;
    public int? cad_cid_codigo { get; set; } = 4316907;

}

public class CadastroContato
{
    public string? cad_contato { get; set; }
    public string? cad_fonecontato { get; set; }
    public string? cad_email { get; set; }
    public string? cad_site { get; set; }
    public string? cad_fone1 { get; set; }
    public string? cad_fone2 { get; set; }
    public string? cad_fone3 { get; set; }
    public short cad_whats1 { get; set; }
    public short cad_whats2 { get; set; }
    public short cad_whats3 { get; set; }
    public string? cad_cli_ref1fone { get; set; }
    public string? cad_cli_ref2fone { get; set; }
    public string? cad_cli_ref3fone { get; set; }
    public string? cad_cli_ref1relacao { get; set; }
    public string? cad_cli_ref2relacao { get; set; }
    public string? cad_cli_ref3relacao { get; set; }
}

public class CadastroCredito
{
    public int cad_cli_usu { get; set; }
    public decimal? cad_cli_desconto { get; set; }
    public int? cad_cli_catcli_key { get; set; }
    public decimal? cad_cli_limitetotal { get; set; }
    public decimal? cad_cli_limitemensal { get; set; }
    public int? cad_cli_limiteparcelas { get; set; }
    public decimal? cad_cli_rendacomprovada { get; set; }
    public string? cad_cli_comprovanterenda { get; set; }
    public decimal? cad_cli_renda { get; set; }
    public decimal? cad_cli_juros { get; set; } = -2;
    public short? cad_cli_liberado { get; set; }
}