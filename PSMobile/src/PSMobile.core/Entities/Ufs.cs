using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class Ufs : BaseEntity
{
    [Key]
    public int ufs_codigo { get; set; }
    public string ufs_uf { get; set; }
    public string ufs_nome { get; set; }
    public decimal ufs_icms { get; set; }
    public ICollection<Cidades>? Cidades { get; set; }

    public override void Deletar() { }
    public override void ReAtivar() { }

}