using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class ReceituarioOculosArmacaoMaterial : Entity
{
    [Key]
    public int recocuarmmat_key { get; set; }
    public int recocuarmmat_recocu_key { get; set; }
    public int recocuarmmat_tipmat_key { get; set; }
    public short recocuarmmat_exc { get; set; }
    public DateTime recocuarmmat_data_mud { get; set; }
    public int recocuarmmat_usu { get; set; }
    public string recocuarmmat_comput { get; set; }

    public TiposMateriais? TiposMateriais { get; set; } = null;
    public ReceituarioOculos? ReceituarioOculos { get; set; } = null;
}