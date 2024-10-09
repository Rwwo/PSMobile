using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;
[Table("usuarios")]
public class Usuarios : Entity
{
    [Key]
    public int usu_key { get; set; }
    public short usu_exc { get; set; }
    public DateTime? usu_dataexc { get; set; }
    public short usu_flag { get; set; }
    public DateTime? usu_datafla { get; set; }
    public string? usu_comput { get; set; }
    public int? usu_usu { get; set; }
    public string? usu_nome { get; set; }
    public string? usu_senha { get; set; }
    public string? usu_permissoes { get; set; }
    public int usu_codigo { get; set; }
    public int usu_emp_key { get; set; }
    public short usu_acessoexterno { get; set; }
    public string? usu_sinc { get; set; }
    public int? usu_fun_key { get; set; }
}
