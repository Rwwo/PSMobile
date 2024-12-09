using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class ReceituarioOculosAnexos
{
    [Key]
    public int recocuane_key { get; set; }
    public int recocuane_recocu_key { get; set; }
    public string recocuane_nome_arquivo { get; set; }
    public byte[] recocuane_arquivo { get; set; }
    public short recocuane_exc { get; set; }
    public DateTime recocuane_data_mud { get; set; }
    public int recocuane_usu { get; set; }
    public string recocuane_comput { get; set; }


    public ReceituarioOculos? ReceituarioOculos { get; set; } = null;

}
