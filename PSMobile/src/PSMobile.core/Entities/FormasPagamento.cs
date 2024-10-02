using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("formaspagamento")]
public class FormasPagamento : Entity
{
    [Key]
    public int forpag_codigo { get; set; }
    public string forpag_nome { get; set; }
    public int forpag_parcelas { get; set; }
    public short forpag_cliente { get; set; }
    public short forpag_carne { get; set; }
    public short forpag_vinculado { get; set; }
    public short forpag_exc { get; set; }
    public DateTime? forpag_dataexc { get; set; }
    public DateTime? forpag_datamud { get; set; }
    public int forpag_usu { get; set; }
    public string? forpag_comput { get; set; }
    public short forpag_diasinicio { get; set; }
    public short forpag_diasintervalo { get; set; }
    public short forpag_exigirparcelas { get; set; }
    public short forpag_tipoparcela { get; set; }
    public short forpag_vinculoextra { get; set; }
    public short forpag_recebimento { get; set; }
    public string? forpag_informacaonfe { get; set; }
    public short forpag_contravale { get; set; }
    public string? forpag_sinc { get; set; }
    public short forpag_troca { get; set; }
    public int? forpag_cam_key { get; set; }
    public short forpag_tpag { get; set; }
    public string? forpag_operadora { get; set; }
    public short forpag_exigirsupervisor { get; set; }
    public int? forpag_parcelasjuros { get; set; }
    public decimal? forpag_juros { get; set; }
    public int? forpag_parcelassupervisor { get; set; }
    public int? forpag_cre_key { get; set; }
    public short forpag_semdesconto { get; set; }
    public short forpag_comissaoavista { get; set; }

    public ICollection<PedidosFormasPagamento> PedidosFormasPagamento { get; } = null!;

    public override string ToString()
    {
        return $"{forpag_codigo} - {forpag_nome}";

    }

}