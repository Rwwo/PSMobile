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
    public string cad_nome { get; set; } = string.Empty;
    public string? cad_obs { get; set; } = null;
    public string? cad_rg { get; set; } = null;
    public string? cad_orgao { get; set; } = null;
    public DateTime? cad_datanasfun { get; set; } = null;

    public int? cad_cli_grucli_key { get; set; } = 0;
    public int? cad_cli_estadocivil { get; set; } = 0;


    // Relacionamentos
    public CadastroCliente? CadastroCliente { get; set; }
    public CadastroFornecedor? CadastroFornecedor { get; set; }
    public CadastroTransportadora? CadastroTransportadora { get; set; }
    public CadastroContato? CadastroContato { get; set; }
    public CadastroEndereco? CadastroEndereco { get; set; }
    public CadastroEndereco? CadastroEnderecoEntrega { get; set; }
    public CadastroEndereco? CadastroEnderecoCorrespondencia { get; set; }
    public ClientesOtica? ClientesOtica { get; set; }
    public ICollection<Pedidos>? Pedidos { get; } = null;
    public ICollection<OrdensServicos>? OrdensServicos { get; } = null;

    public override string ToString()
    {
        return $"{cad_nome}";
    }
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
