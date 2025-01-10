using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class ClientesOtica : Entity
{
    [Key]
    public int clioti_key { get; set; }
    public string? clioti_nome { get; set; }
    //public object clioti_nome_tokens { get; set; }
    public string? clioti_cpf { get; set; }
    public string? clioti_endereco { get; set; }
    public string? clioti_complemento { get; set; }

    public string? clioti_fone1 { get; set; }
    public short clioti_whats1 { get; set; }

    public string? clioti_fone2 { get; set; }
    public short clioti_whats2 { get; set; }

    public string? clioti_fone3 { get; set; }
    public short clioti_whats3 { get; set; }

    public DateTime clioti_data_mud { get; set; }
    public int clioti_usu { get; set; }
    public string? clioti_comput { get; set; }
    public short clioti_exc { get; set; }
    public int? clioti_cad_key { get; set; }

    public Cadastros? Cadastros { get; set; } = null;
}

public class ClientesOticaBuilder
{
    private ClientesOtica? CliOti = null;
    public ClientesOticaBuilder()
    {
        CliOti = new ClientesOtica();
        CliOti.clioti_data_mud = DateTime.Now;
        CliOti.clioti_comput = Environment.MachineName;
    }

    public void ComDadosPessoais(string _clioti_nome, string _clioti_cpf, string _clioti_endereco, string _clioti_complemento, int _clioti_cad_key)
    {
        CliOti.clioti_nome = _clioti_nome;
        CliOti.clioti_cpf = _clioti_cpf;
        CliOti.clioti_endereco = _clioti_endereco;
        CliOti.clioti_complemento = _clioti_complemento;
        CliOti.clioti_cad_key = _clioti_cad_key;
    }

    public void ComNumerosContatos(string _fone1, short _isWhats1, string _fone2, short _isWhats2, string _fone3, short _isWhats3)
    {
        CliOti.clioti_fone1 = _fone1;
        CliOti.clioti_whats1 = _isWhats1;

        CliOti.clioti_fone2 = _fone2;
        CliOti.clioti_whats2 = _isWhats2;

        CliOti.clioti_fone3 = _fone3;
        CliOti.clioti_whats3 = _isWhats3;
    }


    public ClientesOtica Builder()
    {
        return CliOti;
    }
}
