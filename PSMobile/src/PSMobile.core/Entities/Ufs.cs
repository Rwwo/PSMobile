using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class Ufs : Entity
{
    [Key]
    public int ufs_codigo { get; set; }
    public string ufs_uf { get; set; } = null!;
    public string ufs_nome { get; set; } = null!;
    public decimal ufs_icms { get; set; }
    public ICollection<Cidades>? Cidades { get; set; }


}
