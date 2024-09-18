namespace PSMobile.core.Entities;

public class CadastroCredito
{
    public int cad_cli_usu { get; set; }
    public decimal cad_cli_desconto { get; set; } = 0;
    public int? cad_cli_catcli_key { get; set; }
    public decimal? cad_cli_limitetotal { get; set; } = null;
    public decimal? cad_cli_limitemensal { get; set; } = null;
    public int? cad_cli_limiteparcelas { get; set; } = null;
    public decimal? cad_cli_rendacomprovada { get; set; } = null;
    public string? cad_cli_comprovanterenda { get; set; } = null;
    public decimal? cad_cli_renda { get; set; } = null;
    public decimal? cad_cli_juros { get; set; } = -2;
    public short? cad_cli_liberado { get; set; } = null;
}