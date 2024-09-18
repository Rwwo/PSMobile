namespace PSMobile.core.Entities;

public class CadastroFornecedor : BaseEntity
{
    public string? cad_for_suframa { get; set; } = null;
    public int? cad_for_grufor_key { get; set; } = null;
    public short cad_for_creditoicms { get; set; } = 1;
    public short? cad_for_exc { get; set; } = null;
    public DateTime? cad_for_dataexc { get; set; } = null;
    public int cad_for_usu { get; set; }
    public string? cad_for_comput { get; set; } = "";
    public DateTime? cad_for_datamud { get; set; } = null;
    public DateTime? cad_for_datacad { get; set; } = null;
    public short cad_for_liberado { get; set; } = 1;
    public short cad_for_fornecedor { get; set; }
    public int cad_for_contacontabil { get; set; }
    public short cad_for_prestador { get; set; }

    public override void Deletar()
    {
        cad_for_exc = 1;
        cad_for_dataexc = DateTime.Now;
        cad_for_datamud = DateTime.Now;
    }

    public override void ReAtivar()
    {
        cad_for_exc = null;
        cad_for_dataexc = null;
        cad_for_datamud = DateTime.Now;
    }
}
