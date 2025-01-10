using MediatR.NotificationPublishers;

using System;
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
    public string? recocu_mov_num { get; set; }
    public int? recocu_clioti_key { get; set; }
    public int? recocu_cad_key { get; set; }
    public int? recocu_pre_key { get; set; }
    public string? recocu_lente { get; set; }
    public string? recocu_cor { get; set; }
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
    public int? recocu_tipmat_key { get; set; }
    public decimal? recocu_lonodesf { get; set; }
    public decimal? recocu_lonodcil { get; set; }
    public decimal? recocu_lonodeixo { get; set; }
    public decimal? recocu_lonoddnp { get; set; }
    public decimal? recocu_lonoeesf { get; set; }
    public decimal? recocu_lonoecil { get; set; }
    public decimal? recocu_lonoeeixo { get; set; }
    public decimal? recocu_lonoednp { get; set; }
    public decimal? recocu_perodesf { get; set; }
    public decimal? recocu_perodcil { get; set; }
    public decimal? recocu_perodeixo { get; set; }
    public decimal? recocu_peroddnp { get; set; }
    public decimal? recocu_peroeesf { get; set; }
    public decimal? recocu_peroecil { get; set; }
    public decimal? recocu_peroeeixo { get; set; }
    public decimal? recocu_peroednp { get; set; }
    public decimal? recocu_altura { get; set; }
    public decimal? recocu_vertical { get; set; }
    public decimal? recocu_diagonal { get; set; }
    public decimal? recocu_adicao { get; set; }
    public decimal? recocu_ponte { get; set; }
    public decimal? recocu_horizontal { get; set; }
    public string? recocu_observacao { get; set; } = null;
    public short recocu_exc { get; set; }
    public DateTime recocu_data_mud { get; set; }
    public int recocu_usu { get; set; }
    public string? recocu_comput { get; set; }
    public short recocu_vta_entregue { get; set; }
    public string? recocu_id { get; set; } = null;
    public string? recocu_sinc { get; set; } = null;
    public short? recocu_sincenviar { get; set; } = null;
    public decimal? recocu_valorlente { get; set; }
    public decimal? recocu_valorarmacao { get; set; }
    public bool recocu_livro { get; set; }

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

public class ReceituarioOculosBuilder
{
    private ReceituarioOculos? Rec = null;
    public ReceituarioOculosBuilder()
    {
        Rec = new ReceituarioOculos();
        Rec.recocu_data_mud = DateTime.Now;

        Rec.recocu_comput = Environment.MachineName;
    }

    public void ComId(int id)
    {
        Rec.recocu_key = id;
    }
    public void ComDadosCabecalho(DateTime _recocu_data_abert,
                                  DateTime _recocu_data_prev,
                                  DateTime _recocu_data_renov,
                                  DateTime? _recocu_data_fech,
                                  int _recocu_emp_key,
                                  int? _recocu_fun_key,
                                  string _recocu_mov_num,
                                  int? _recocu_clioti_key,
                                  int? _recocu_cad_key,
                                  int? _recocu_pre_key
                                 )
    {
        Rec.recocu_data_abert = _recocu_data_abert;
        Rec.recocu_data_prev = _recocu_data_prev;
        Rec.recocu_data_renov = _recocu_data_renov;
        Rec.recocu_data_fech = _recocu_data_fech;

        Rec.recocu_emp_key = _recocu_emp_key;
        Rec.recocu_fun_key = _recocu_fun_key;
        Rec.recocu_mov_num = _recocu_mov_num;
        Rec.recocu_clioti_key = _recocu_clioti_key;
        Rec.recocu_cad_key = _recocu_cad_key;
        Rec.recocu_pre_key = _recocu_pre_key;
    }
    public void ComDadosLente(
        string _recocu_lente,
        string _recocu_cor,
        short _recocu_cr39,
        short _recocu_poli,
        short _recocu_trivex,
        short _recocu_cristal,
        decimal? _recocu_valorlente
        )
    {
        Rec.recocu_lente = _recocu_lente;
        Rec.recocu_cor = _recocu_cor;
        Rec.recocu_cr39 = _recocu_cr39;
        Rec.recocu_poli = _recocu_poli;
        Rec.recocu_trivex = _recocu_trivex;
        Rec.recocu_cristal = _recocu_cristal;
        Rec.recocu_valorlente = _recocu_valorlente;
    }
    public void ComDadosArmacao(
        short _recocu_vta,
        short _recocu_vtanodia,
        DateTime? _recocu_vta_data,
        string? _recocu_armacao,
        string? _recocu_referencia,
        string? _recocu_pro_codigo,
        int? _recocu_tipmat_key,
        decimal? _recocu_valorarmacao,
        short _recocu_vta_entregue
        )
    {
        Rec.recocu_vta = _recocu_vta;
        Rec.recocu_vtanodia = _recocu_vtanodia;
        Rec.recocu_vta_data = _recocu_vta_data;
        Rec.recocu_armacao = _recocu_armacao;
        Rec.recocu_referencia = _recocu_referencia;
        Rec.recocu_pro_codigo = _recocu_pro_codigo;
        Rec.recocu_tipmat_key = _recocu_tipmat_key;
        Rec.recocu_valorarmacao = _recocu_valorarmacao;
        Rec.recocu_vta_entregue = _recocu_vta_entregue;
    }

    public void ComDadosDiopmetria(
        decimal? _recocu_lonodesf,
        decimal? _recocu_lonodcil,
        decimal? _recocu_lonodeixo,
        decimal? _recocu_lonoddnp,
        decimal? _recocu_lonoeesf,
        decimal? _recocu_lonoecil,
        decimal? _recocu_lonoeeixo,
        decimal? _recocu_lonoednp,
        decimal? _recocu_perodesf,
        decimal? _recocu_perodcil,
        decimal? _recocu_perodeixo,
        decimal? _recocu_peroddnp,
        decimal? _recocu_peroeesf,
        decimal? _recocu_peroecil,
        decimal? _recocu_peroeeixo,
        decimal? _recocu_peroednp,
        decimal? _recocu_altura,
        decimal? _recocu_vertical,
        decimal? _recocu_diagonal,
        decimal? _recocu_adicao,
        decimal? _recocu_ponte,
        decimal? _recocu_horizontal,
        string _recocu_observacao
        )
    {
        Rec.recocu_lonodesf = _recocu_lonodesf;
        Rec.recocu_lonodcil = _recocu_lonodcil;
        Rec.recocu_lonodeixo = _recocu_lonodeixo;
        Rec.recocu_lonoddnp = _recocu_lonoddnp;
        Rec.recocu_lonoeesf = _recocu_lonoeesf;
        Rec.recocu_lonoecil = _recocu_lonoecil;
        Rec.recocu_lonoeeixo = _recocu_lonoeeixo;
        Rec.recocu_lonoednp = _recocu_lonoednp;
        Rec.recocu_perodesf = _recocu_perodesf;
        Rec.recocu_perodcil = _recocu_perodcil;
        Rec.recocu_perodeixo = _recocu_perodeixo;
        Rec.recocu_peroddnp = _recocu_peroddnp;
        Rec.recocu_peroeesf = _recocu_peroeesf;
        Rec.recocu_peroecil = _recocu_peroecil;
        Rec.recocu_peroeeixo = _recocu_peroeeixo;
        Rec.recocu_peroednp = _recocu_peroednp;
        Rec.recocu_altura = _recocu_altura;
        Rec.recocu_vertical = _recocu_vertical;
        Rec.recocu_diagonal = _recocu_diagonal;
        Rec.recocu_adicao = _recocu_adicao;
        Rec.recocu_ponte = _recocu_ponte;
        Rec.recocu_horizontal = _recocu_horizontal;
        Rec.recocu_observacao = _recocu_observacao;
    }

    public ReceituarioOculos Build()
    {
        return Rec;
    }
}
