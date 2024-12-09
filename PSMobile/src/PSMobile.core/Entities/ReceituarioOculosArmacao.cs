using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class ReceituarioOculosArmacao : Entity
{
    [Key]
    public int recocuarm_key { get; set; }
    public int recocuarm_recocu_key { get; set; }
    public string recocuarm_observacao { get; set; }
    public DateTime recocuarm_data_ent { get; set; }
    public short recocuarm_exc { get; set; }
    public DateTime recocuarm_data_mud { get; set; }
    public int recocuarm_usu { get; set; }
    public string recocuarm_comput { get; set; }


    public ReceituarioOculos? ReceituarioOculos { get; set; } = null;
}
