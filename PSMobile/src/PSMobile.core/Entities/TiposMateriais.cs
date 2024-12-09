using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class TiposMateriais : Entity
{
    [Key]
    public int tipmat_key { get; set; }
    public string? tipmat_descricao { get; set; } = null;
    public short tipmat_exc { get; set; }
    public DateTime tipmat_data_mud { get; set; }
    public int tipmat_usu { get; set; }
    public string? tipmat_comput { get; set; } = null;
    public string? tipmat_sinc { get; set; } = null;
}