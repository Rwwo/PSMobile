using PSMobile.core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMobile.core.InputModel;
public class ClienteOticaInputModel : PSMobile.core.Entities.InputModel
{
    public int clioti_key { get; set; }

    [Required]
    public string? clioti_nome { get; set; }

    //public object clioti_nome_tokens { get; set; }
    public string? clioti_cpf { get; set; }
    public string? clioti_endereco { get; set; }
    public string? clioti_complemento { get; set; }

    public string? clioti_fone1 { get; set; }
    public bool clioti_whats1 { get; set; }

    public string? clioti_fone2 { get; set; }
    public bool clioti_whats2 { get; set; }

    public string? clioti_fone3 { get; set; }
    public bool clioti_whats3 { get; set; }
    public DateTime clioti_data_mud { get; set; }
    public int clioti_usu { get; set; }
    public string? clioti_comput { get; set; }
    public short clioti_exc { get; set; }

    [Required]
    public int clioti_cad_key { get; set; }
}
