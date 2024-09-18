namespace PSMobile.core.Entities;

public class CadastroCliente : BaseEntity
{
    public string? cad_cli_naturalidade { get; set; } = null;
    public short? cad_cli_exc { get; set; } = null;
    public DateTime? cad_cli_dataexc { get; set; } = null;
    public int cad_cli_usu { get; set; }
    public string? cad_cli_comput { get; set; } = "";
    public DateTime? cad_cli_datamud { get; set; } = null;
    public DateTime? cad_cli_datacad { get; set; } = null;
    public short? cad_cli_liberado { get; set; } = 1;
    public int? cad_cli_diastolerancia { get; set; } = null;
    public CadastroCredito CadastroCredito { get; set; }

    public override void Deletar()
    {
        cad_cli_exc = 1;
        cad_cli_dataexc = DateTime.Now;
        cad_cli_datamud = DateTime.Now;
    }
    public override void ReAtivar()
    {
        cad_cli_exc = null;
        cad_cli_dataexc = null;
        cad_cli_datamud = DateTime.Now;
    }
}
