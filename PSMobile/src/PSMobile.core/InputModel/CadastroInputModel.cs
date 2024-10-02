using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PSMobile.core.InputModel;

public class CadastroInputModel : PSMobile.core.Entities.InputModel
{

    // Dados de Identificação e Básicos
    public int Key { get; set; }
    public string? Cnpj { get; set; } = null;
    public string? Sexo { get; set; } = null;

    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }
    public string? Razao { get; set; } = null;
    public string? Ie { get; set; } = null;
    public string? Im { get; set; } = null;
    public string? Ist { get; set; } = null;

    // Dados de Contato
    public string? Fone1 { get; set; } = null;
    public string? Fone2 { get; set; } = null;
    public string? Fone3 { get; set; } = null;
    public string? Contato { get; set; } = null;
    public string? FoneContato { get; set; } = null;
    public string? Email { get; set; } = null;
    public string? Site { get; set; } = null;

    // Documentação
    public string? Rg { get; set; } = null;
    public string? Orgao { get; set; } = null;
    public DateTime? DataNasFun { get; set; }

    // Informações de Cliente
    public DateTime? CliDataCad { get; set; } = null;
    public string? Obs { get; set; } = null;

    // Informações Financeiras
    public decimal? CliLimiteTotal { get; set; } = 0;
    public decimal? CliLimiteMensal { get; set; } = 0;
    public int? CliLimiteParcelas { get; set; } = 0;
    public decimal? CliRendaComprovada { get; set; } = 0;
    public string? CliComprovanteRenda { get; set; } = string.Empty;
    public decimal? CliRenda { get; set; } = 0;
    public int CadCliDiasTolerancia { get; set; } = 0;
    public int CadCliLiberado { get; set; } = 1;

    public string? Cep { get; set; } = null;
    public string? Endereco { get; set; } = null;
    public int? Numero { get; set; } = null;
    public string? Complemento { get; set; } = null;
    public int? UfsCodigo { get; set; } = null;
    public int? CidCodigo { get; set; } = null;
    public string? Bairro { get; set; } = null;

    // Endereço de Entrega
    public string? EntCep { get; set; } = null;
    public string? EntEndereco { get; set; } = null;
    public int? EntNumero { get; set; } = null;
    public string? EntComplemento { get; set; } = null;
    public int? EntUfsCodigo { get; set; } = null;
    public int? EntCidCodigo { get; set; } = null;
    public string? EntBairro { get; set; } = null;

    // Endereço de Correspondência
    public string? CorCep { get; set; } = null;
    public string? CorEndereco { get; set; } = null;
    public int? CorNumero { get; set; } = null;
    public string? CorComplemento { get; set; } = null;
    public int? CorUfsCodigo { get; set; } = null;
    public int? CorCidCodigo { get; set; } = null;
    public string? CorBairro { get; set; } = null;

    // Outros Campos e Flags
    public int? PreencherEnderecos { get; set; } = null;
    public string? CadTipo { get; set; } = null;
    public decimal CadCliDesconto { get; set; } = 0;
    public int? CadPaiCodigo { get; set; } = null;
    public int? CadCorPaiCodigo { get; set; } = null;
    public int? CadEntPaiCodigo { get; set; } = null;


}
