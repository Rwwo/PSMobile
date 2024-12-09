using MediatR.NotificationPublishers;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace PSMobile.core.Entities;

public class ReceituarioOculos : Entity
{
    [Key]
    public int recocu_key { get; set; }
    public int recocu_numos { get; set; }
    public DateTime recocu_data_abert { get; set; }
    public DateTime recocu_data_prev { get; set; }
    public DateTime recocu_data_renov { get; set; }
    public DateTime? recocu_data_fech { get; set; }
    public int recocu_emp_key { get; set; }
    public int? recocu_fun_key { get; set; }
    public string recocu_mov_num { get; set; }
    public int? recocu_clioti_key { get; set; }
    public int? recocu_cad_key { get; set; }
    public int? recocu_pre_key { get; set; }
    public string recocu_lente { get; set; }
    public string recocu_cor { get; set; }
    public short recocu_cr39 { get; set; }
    public short recocu_poli { get; set; }
    public short recocu_trivex { get; set; }
    public short recocu_cristal { get; set; }
    public short recocu_vta { get; set; }
    public short recocu_vtanodia { get; set; }
    public DateTime? recocu_vta_data { get; set; }
    public string? recocu_armacao { get; set; } = null;
    public string? recocu_referencia { get; set; } = null;
    public string? recocu_pro_codigo { get; set; } = null;
    public int recocu_tipmat_key { get; set; }
    public decimal recocu_lonodesf { get; set; }
    public decimal recocu_lonodcil { get; set; }
    public decimal recocu_lonodeixo { get; set; }
    public decimal recocu_lonoddnp { get; set; }
    public decimal recocu_lonoeesf { get; set; }
    public decimal recocu_lonoecil { get; set; }
    public decimal recocu_lonoeeixo { get; set; }
    public decimal recocu_lonoednp { get; set; }
    public decimal recocu_perodesf { get; set; }
    public decimal recocu_perodcil { get; set; }
    public decimal recocu_perodeixo { get; set; }
    public decimal recocu_peroddnp { get; set; }
    public decimal recocu_peroeesf { get; set; }
    public decimal recocu_peroecil { get; set; }
    public decimal recocu_peroeeixo { get; set; }
    public decimal recocu_peroednp { get; set; }
    public decimal recocu_altura { get; set; }
    public decimal recocu_vertical { get; set; }
    public decimal recocu_diagonal { get; set; }
    public decimal recocu_adicao { get; set; }
    public decimal recocu_ponte { get; set; }
    public decimal recocu_horizontal { get; set; }
    public string? recocu_observacao { get; set; } = null;
    public short recocu_exc { get; set; }
    public DateTime recocu_data_mud { get; set; }
    public int recocu_usu { get; set; }
    public string? recocu_comput { get; set; }
    public short recocu_vta_entregue { get; set; }
    public string? recocu_id { get; set; } = null;
    public string? recocu_sinc { get; set; } = null;
    public short? recocu_sincenviar { get; set; } = null;
    public decimal recocu_valorlente { get; set; }
    public decimal recocu_valorarmacao { get; set; }

    public Funcionarios? Funcionarios { get; set; } = null;
    public Cadastros? Cadastros { get; set; } = null;
    public ClientesOtica? ClientesOtica { get; set; } = null;
    public TiposMateriais? TiposMateriais { get; set; } = null;
    public Prescritores? Prescritores { get; set; } = null;

    public List<ReceituarioOculosAnexos>? ReceituarioOculosAnexos { get; set; } = null;
    public List<ReceituarioOculosArmacao>? ReceituarioOculosArmacao { get; set; } = null;
    public List<ReceituarioOculosArmacaoMaterial>? ReceituarioOculosArmacaoMaterial { get; set; } = null;

    public string _recocu_vta => (
    (this.recocu_vta == 1 ? (this.recocu_vta_entregue == 1 ? string.Format("Já trouxe") : (this.recocu_vtanodia == 1 ? "Trará no dia"
                                : string.Format("Trará no dia {0}", this.recocu_vta_data.HasValue == true ? Convert.ToDateTime(this.recocu_vta_data) : this.recocu_data_prev)))
    : "Não"));

    public bool _status => this.recocu_data_fech != null ? true : false;

}
