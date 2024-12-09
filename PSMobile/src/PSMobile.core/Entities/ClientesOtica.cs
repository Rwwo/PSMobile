using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class ClientesOtica : Entity
{
    [Key]
    public int clioti_key { get; set; }
    public string clioti_nome { get; set; }
    //public object clioti_nome_tokens { get; set; }
    public string clioti_cpf { get; set; }
    public string clioti_endereco { get; set; }
    public string clioti_complemento { get; set; }
    public short clioti_whats1 { get; set; }
    public short clioti_whats2 { get; set; }
    public short clioti_whats3 { get; set; }
    public DateTime clioti_data_mud { get; set; }
    public int clioti_usu { get; set; }
    public string clioti_comput { get; set; }
    public short clioti_exc { get; set; }
    public int? clioti_cad_key { get; set; }
}
