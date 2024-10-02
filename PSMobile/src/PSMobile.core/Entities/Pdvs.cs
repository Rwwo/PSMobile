using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("pdvs")]
public class Pdvs : Entity
{
    [Key]
    public int pdv_key { get; set; }
    public int pdv_emp_key { get; set; }

    public int pdv_numero { get; set; }
    public string pdv_local { get; set; } = null!;
    public DateTime? pdv_datacad { get; set; }
    public DateTime? pdv_datamud { get; set; }
    public int? pdv_usu { get; set; }
    public string? pdv_comput { get; set; }
    public short pdv_exc { get; set; }
    public DateTime? pdv_dataexc { get; set; }
    public short pdv_transmitir { get; set; }
    public DateTime? pdv_datatra { get; set; }
    public int? pdv_porta { get; set; }
    public string? pdv_senhapostgres { get; set; }
    public int? pdv_nfceserie { get; set; }
    public int? pdv_nfcenumero { get; set; }
    public int? pdv_tefpdv { get; set; }
    public string? pdv_sinc { get; set; }
    public int? pdv_numerocaixa { get; set; }
    public int pdv_emitenfe { get; set; }
    public short pdv_emitirespelhonfe { get; set; }

}