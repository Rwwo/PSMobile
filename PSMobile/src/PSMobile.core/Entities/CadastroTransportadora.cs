namespace PSMobile.core.Entities;

public class CadastroTransportadora : BaseEntity
{
    public short? cad_tra_exc { get; set; }
    public DateTime? cad_tra_dataexc { get; set; }
    public int cad_tra_usu { get; set; }
    public string? cad_tra_comput { get; set; } = "";
    public DateTime? cad_tra_datamud { get; set; } = null;
    public DateTime? cad_tra_datacad { get; set; } = null;
    public string? cad_rntrc { get; set; } = null;
    public short cad_rntrctipoproprietario { get; set; } = -1;
    public short cad_tra_liberado { get; set; } = 1;

    public override void Deletar()
    {
        cad_tra_exc = 1;
        cad_tra_dataexc = DateTime.Now;
        cad_tra_datamud = DateTime.Now;
    }
    public override void ReAtivar()
    {
        cad_tra_exc = null;
    }
}
