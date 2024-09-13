namespace PSMobile.SharedKernel.Common.Dtos;

public class ClienteInputModel
{
    // Dados de Identificação e Básicos
    public int Key { get; set; }
    public string Cnpj { get; set; }
    public string Sexo { get; set; }
    public string Nome { get; set; }
    public string Razao { get; set; }
    public string Ie { get; set; }
    public string Im { get; set; }
    public string Ist { get; set; }

    // Dados de Contato
    public string Fone1 { get; set; }
    public string Fone2 { get; set; }
    public string Fone3 { get; set; }
    public string Contato { get; set; }
    public string FoneContato { get; set; }
    public string Email { get; set; }
    public string Site { get; set; }

    // Documentação
    public string Rg { get; set; }
    public string Orgao { get; set; }
    public DateTime? DataNasFun { get; set; }

    // Informações de Cliente
    public DateTime? CliDataCad { get; set; }
    public string Obs { get; set; }
    public int CliUsu { get; set; }
    public string CliComput { get; set; }

    // Informações Financeiras
    public decimal? CliLimiteTotal { get; set; }
    public decimal? CliLimiteMensal { get; set; }
    public int? CliLimiteParcelas { get; set; }
    public decimal? CliRendaComprovada { get; set; }
    public string CliComprovanteRenda { get; set; }
    public decimal? CliRenda { get; set; }

    public string Cep { get; set; }
    public string Endereco { get; set; }
    public int? Numero { get; set; }
    public string Complemento { get; set; }
    public int? UfsCodigo { get; set; }
    public int? CidCodigo { get; set; }
    public string Bairro { get; set; }

    // Endereço de Entrega
    public string EntCep { get; set; }
    public string EntEndereco { get; set; }
    public int? EntNumero { get; set; }
    public string EntComplemento { get; set; }
    public int? EntUfsCodigo { get; set; }
    public int? EntCidCodigo { get; set; }
    public string EntBairro { get; set; }

    // Endereço de Correspondência
    public string CorCep { get; set; }
    public string CorEndereco { get; set; }
    public int? CorNumero { get; set; }
    public string CorComplemento { get; set; }
    public int? CorUfsCodigo { get; set; }
    public int? CorCidCodigo { get; set; }
    public string CorBairro { get; set; }

    // Outros Campos e Flags
    public int? PreencherEnderecos { get; set; }
    public string CadTipo { get; set; }
    public decimal? CadCliDesconto { get; set; }
    public int? CadPaiCodigo { get; set; }
    public int? CadCorPaiCodigo { get; set; }
    public int? CadEntPaiCodigo { get; set; }


}
