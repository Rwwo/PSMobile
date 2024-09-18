using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

public class Cidades : BaseEntity
{
    [Key]
    public int cid_key { get; set; }
    public int cid_codigo { get; set; }
    public string cid_nome { get; set; }
    public string cid_cep { get; set; }
    public DateTime cid_datamud { get; set; }
    public int cid_pai_codigo { get; set; }

    public int cid_ufs_codigo { get; set; }



    public Ufs Ufs { get; set; }

    public override void Deletar() { }
    public override void ReAtivar() { }

    public string CidadeNormalizado => this.ToString();
    public override string ToString() => $"{cid_nome} - {Ufs.ufs_uf}";
}
