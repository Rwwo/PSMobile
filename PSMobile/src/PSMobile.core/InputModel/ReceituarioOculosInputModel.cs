using PSMobile.core.Entities;

namespace PSMobile.core.InputModel;

public class ReceituarioOculosInputModel : PSMobile.core.Entities.InputModel
{

    public ReceituarioOculosInputModel()
    {
        recocu_data_abert = DateTime.Now;

        recocu_data_prev = recocu_data_abert.Value.AddYears(1);
        recocu_data_renov = recocu_data_abert.Value.AddYears(1);
    }

    public ReceituarioOculosInputModel AdicionarExistente(ReceituarioOculos input)
    {
        recocu_emp_key = input.recocu_emp_key;
        recocu_fun_key = input.recocu_fun_key;
        recocu_clioti_key = input.recocu_clioti_key;
        recocu_cad_key = input.recocu_cad_key;
        recocu_pre_key = input.recocu_pre_key;
        recocu_key = input.recocu_key;
        recocu_numos = input.recocu_numos;
        recocu_data_abert = input.recocu_data_abert;
        recocu_data_prev = input.recocu_data_prev;
        recocu_data_renov = input.recocu_data_renov;
        recocu_data_fech = (DateTime)input.recocu_data_fech;
        recocu_mov_num = input.recocu_mov_num;
        recocu_lente = input.recocu_lente;
        recocu_cor = input.recocu_cor;
        recocu_cr39 = input.recocu_cr39;
        recocu_poli = input.recocu_poli;
        recocu_trivex = input.recocu_trivex;
        recocu_cristal = input.recocu_cristal;
        _recocu_vta = input.recocu_vta == 1 ? true : false;
        _recocu_vtanodia = input.recocu_vtanodia == 1 ? true : false;
        recocu_vta_data = input.recocu_vta_data;
        recocu_armacao = input.recocu_armacao;
        recocu_referencia = input.recocu_referencia;
        recocu_pro_codigo = input.recocu_pro_codigo;
        recocu_tipmat_key = input.recocu_tipmat_key;
        recocu_lonodesf = input.recocu_lonodesf;
        recocu_lonodcil = input.recocu_lonodcil;
        recocu_lonodeixo = input.recocu_lonodeixo;
        recocu_lonoddnp = input.recocu_lonoddnp;
        recocu_lonoeesf = input.recocu_lonoeesf;
        recocu_lonoecil = input.recocu_lonoecil;
        recocu_lonoeeixo = input.recocu_lonoeeixo;
        recocu_lonoednp = input.recocu_lonoednp;
        recocu_perodesf = input.recocu_perodesf;
        recocu_perodcil = input.recocu_perodcil;
        recocu_perodeixo = input.recocu_perodeixo;
        recocu_peroddnp = input.recocu_peroddnp;
        recocu_peroeesf = input.recocu_peroeesf;
        recocu_peroecil = input.recocu_peroecil;
        recocu_peroeeixo = input.recocu_peroeeixo;
        recocu_peroednp = input.recocu_peroednp;
        recocu_altura = input.recocu_altura;
        recocu_vertical = input.recocu_vertical;
        recocu_diagonal = input.recocu_diagonal;
        recocu_adicao = input.recocu_adicao;
        recocu_ponte = input.recocu_ponte;
        recocu_horizontal = input.recocu_horizontal;
        recocu_observacao = input.recocu_observacao;
        recocu_exc = input.recocu_exc;
        recocu_data_mud = input.recocu_data_mud;
        recocu_usu = input.recocu_usu;
        recocu_comput = input.recocu_comput;
        recocu_vta_entregue = input.recocu_vta_entregue;
        recocu_id = input.recocu_id;
        recocu_sinc = input.recocu_sinc;
        recocu_sincenviar = input.recocu_sincenviar;
        recocu_valorlente = input.recocu_valorlente;
        recocu_valorarmacao = input.recocu_valorarmacao;

        Funcionario = input.Funcionarios;
        recocu_fun_key = Funcionario?.fun_key;

        Cadastros = input.Cadastros;
        recocu_cad_key = Cadastros?.cad_key;

        TipoMateriais = input.TiposMateriais;
        recocu_tipmat_key = TipoMateriais.tipmat_key;

        Prescritor = input.Prescritores;
        recocu_pre_key = Prescritor?.pre_key;

        ClientesOtica = input.ClientesOtica;
        recocu_clioti_key = ClientesOtica?.clioti_key;

        return this;
    }

    #region Dados do Objeto
    public int recocu_key { get; set; }
    public int? recocu_numos { get; set; } = null;
    public DateTime? recocu_data_abert { get; set; }
    public DateTime? recocu_data_prev { get; set; }
    public DateTime? recocu_data_renov { get; set; }
    public DateTime? recocu_data_fech { get; set; }
    public string recocu_mov_num { get; set; }
    public string recocu_lente { get; set; }
    public string recocu_cor { get; set; }
    public short recocu_cr39 { get; set; }
    public short recocu_poli { get; set; }
    public short recocu_trivex { get; set; }
    public short recocu_cristal { get; set; }
    public short recocu_vta => _recocu_vta == true ? (short)1 : (short)0;
    public bool _recocu_vta { get; set; } = false;
    public short recocu_vtanodia => _recocu_vtanodia == true ? (short)1 : (short)0;
    public bool _recocu_vtanodia { get; set; } = false;
    public DateTime? recocu_vta_data { get; set; }
    public string? recocu_armacao { get; set; } = null;
    public string? recocu_referencia { get; set; } = null;
    public string? recocu_pro_codigo { get; set; } = null;
    public int recocu_tipmat_key { get; set; }


    #region Longe OD

    private decimal? _recocu_lonodesf;
    public decimal? recocu_lonodesf
    {
        get => _recocu_lonodesf;
        set
        {
            if (_recocu_lonodesf != value)
            {
                _recocu_lonodesf = value;
                OnRecocuLonodesfChanged();
            }
        }
    }
    private void OnRecocuLonodesfChanged()
    {
        if (recocu_adicao.HasValue)
        {
            recocu_perodesf = _recocu_lonodesf + recocu_adicao;
        }
    }


    private decimal? _recocu_lonodcil;
    public decimal? recocu_lonodcil
    {
        get => _recocu_lonodcil;
        set
        {
            if (_recocu_lonodcil != value)
            {
                _recocu_lonodcil = value;
                OnRecocuLonodcilChanged();
            }
        }
    }
    private void OnRecocuLonodcilChanged()
    {
        if (recocu_adicao.HasValue)
        {
            recocu_perodcil = _recocu_lonodcil + recocu_adicao;
        }
    }


    private decimal? _recocu_lonodeixo;
    public decimal? recocu_lonodeixo
    {
        get => _recocu_lonodeixo;
        set
        {
            if (_recocu_lonodeixo != value)
            {
                _recocu_lonodeixo = value;
                FormattedEixo_lonodeixo = FormatEixo(value);
            }
        }
    }
    public string FormattedEixo_lonodeixo { get; set; }
    private string FormatEixo(decimal? value)
    {
        if (value.HasValue && value >= 0 && value <= 180)
        {
            return $"{value}º";
        }
        return null;
    }
    public void OnBlurEixo_lonodeixo()
    {
        // Remove o sufixo ao sair do foco, mas mantém a formatação no setter da propriedade.
        if (decimal.TryParse(FormattedEixo_lonodeixo?.Replace("º", ""), out var result))
        {
            recocu_lonodeixo = result;

            if (recocu_adicao.HasValue)
            {
                recocu_perodeixo = recocu_lonodeixo;
            }
        }
    }

    public decimal? recocu_lonoddnp { get; set; }

    #endregion

    #region LONGE OE

    private decimal? _recocu_lonoeesf;
    public decimal? recocu_lonoeesf
    {
        get => _recocu_lonoeesf;
        set
        {
            if (_recocu_lonoeesf != value)
            {
                _recocu_lonoeesf = value;
                OnRecocuLonoeesfChanged();
            }
        }
    }
    private void OnRecocuLonoeesfChanged()
    {
        if (recocu_adicao.HasValue)
        {
            recocu_peroeesf = _recocu_lonoeesf + recocu_adicao;
        }
    }


    private decimal? _recocu_lonoecil;
    public decimal? recocu_lonoecil
    {
        get => _recocu_lonoecil;
        set
        {
            if (_recocu_lonoecil != value)
            {
                _recocu_lonoecil = value;
                OnRecocuLonoecilChanged();
            }
        }
    }
    private void OnRecocuLonoecilChanged()
    {
        if (recocu_adicao.HasValue)
        {
            recocu_peroecil = _recocu_lonoecil + recocu_adicao;
        }
    }

    private decimal? _recocu_lonoeeixo;
    public decimal? recocu_lonoeeixo
    {
        get => _recocu_lonoeeixo;
        set
        {
            if (_recocu_lonoeeixo != value)
            {
                _recocu_lonoeeixo = value;
                FormattedEixo_lonoeeixo = FormatEixo(value);
            }
        }
    }
    public string FormattedEixo_lonoeeixo { get; set; }
    public void OnBlurEixo_lonoeeixo()
    {
        // Remove o sufixo ao sair do foco, mas mantém a formatação no setter da propriedade.
        if (decimal.TryParse(FormattedEixo_lonoeeixo?.Replace("º", ""), out var result))
        {
            recocu_lonoeeixo = result;

            if (recocu_adicao.HasValue)
            {
                recocu_peroeeixo = recocu_lonoeeixo;
            }
        }
    }

    public decimal? recocu_lonoednp { get; set; }

    #endregion

    #region Perto OD

    private decimal? _recocu_perodesf;
    public decimal? recocu_perodesf
    {
        get => _recocu_perodesf;
        set
        {
            if (_recocu_perodesf != value)
            {
                _recocu_perodesf = value;
                OnRecocuperodesfChanged();
            }
        }
    }
    private void OnRecocuperodesfChanged()
    {
        if (recocu_adicao.HasValue)
        {
            recocu_lonodesf = _recocu_perodesf - recocu_adicao;
        }
    }


    private decimal? _recocu_perodcil;
    public decimal? recocu_perodcil
    {
        get => _recocu_perodcil;
        set
        {
            if (_recocu_perodcil != value)
            {
                _recocu_perodcil = value;
                OnRecocuperodcilChanged();
            }
        }
    }
    private void OnRecocuperodcilChanged()
    {
        if (recocu_adicao.HasValue)
        {
            recocu_lonodcil = _recocu_perodcil - recocu_adicao;
        }
    }


    private decimal? _recocu_perodeixo;
    public decimal? recocu_perodeixo
    {
        get => _recocu_perodeixo;
        set
        {
            if (_recocu_perodeixo != value)
            {
                _recocu_perodeixo = value;
                FormattedEixo_perodeixo = FormatEixo(value);
            }
        }
    }
    public string FormattedEixo_perodeixo { get; set; }

    public void OnBlurEixo_perodeixo()
    {
        if (decimal.TryParse(FormattedEixo_perodeixo?.Replace("º", ""), out var result))
        {
            recocu_perodeixo = result;

            if (recocu_adicao.HasValue)
            {
                recocu_lonodeixo = recocu_perodeixo;
            }
        }
    }

    public decimal? recocu_peroddnp { get; set; }

    #endregion

    #region Perto OE

    private decimal? _recocu_peroeesf;
    public decimal? recocu_peroeesf
    {
        get => _recocu_peroeesf;
        set
        {
            if (_recocu_peroeesf != value)
            {
                _recocu_peroeesf = value;
                OnRecocuperoeesfChanged();
            }
        }
    }
    private void OnRecocuperoeesfChanged()
    {
        if (recocu_adicao.HasValue)
        {
            recocu_lonoeesf = _recocu_peroeesf - recocu_adicao;
        }
    }


    private decimal? _recocu_peroecil;
    public decimal? recocu_peroecil
    {
        get => _recocu_peroecil;
        set
        {
            if (_recocu_peroecil != value)
            {
                _recocu_peroecil = value;
                OnRecocuperoecilChanged();
            }
        }
    }
    private void OnRecocuperoecilChanged()
    {
        if (recocu_adicao.HasValue)
        {
            recocu_lonoecil = _recocu_peroecil - recocu_adicao;
        }
    }

    private decimal? _recocu_peroeeixo;
    public decimal? recocu_peroeeixo
    {
        get => _recocu_peroeeixo;
        set
        {
            if (_recocu_peroeeixo != value)
            {
                _recocu_peroeeixo = value;
                FormattedEixo_peroeeixo = FormatEixo(value);
            }
        }
    }
    public string FormattedEixo_peroeeixo { get; set; }
    public void OnBlurEixo_peroeeixo()
    {
        // Remove o sufixo ao sair do foco, mas mantém a formatação no setter da propriedade.
        if (decimal.TryParse(FormattedEixo_peroeeixo?.Replace("º", ""), out var result))
        {
            recocu_peroeeixo = result;

            if (recocu_adicao.HasValue)
            {
                recocu_lonoeeixo = recocu_peroeeixo;
            }
        }
    }

    public decimal? recocu_peroednp { get; set; }

    #endregion

    public decimal? recocu_altura { get; set; }
    public decimal? recocu_vertical { get; set; }
    public decimal? recocu_diagonal { get; set; }
    public decimal? recocu_adicao { get; set; }

    public void OnBlurAdicao()
    {
        if (!recocu_adicao.HasValue)
            return;


        if (recocu_lonodesf.HasValue)
            recocu_perodesf = recocu_lonodesf + recocu_adicao;

        if (recocu_lonoeesf.HasValue)
            recocu_peroeesf = recocu_lonoeesf + recocu_adicao;


        if (recocu_lonodcil.HasValue)
            recocu_perodcil = recocu_lonodcil + recocu_adicao;

        if (recocu_lonoecil.HasValue)
            recocu_peroecil = recocu_lonoecil + recocu_adicao;


        if (recocu_lonodeixo.HasValue)
            recocu_perodeixo = recocu_lonodeixo;

        if (recocu_lonoeeixo.HasValue)
            recocu_peroeeixo = recocu_lonoeeixo;



    }
    public string _recocu_adicao
    {
        get => recocu_adicao?.ToString("0.00") ?? string.Empty;
        set => recocu_adicao = decimal.TryParse(value, out var result) ? result : (decimal?)null;
    }

    public void OnTextChangedAdicao(string text)
    {
        // Substitui vírgulas por pontos e verifica se é numérico
        text = text.Replace(".", ",");

        if (decimal.TryParse(text, out var numericValue))
        {
            recocu_adicao = numericValue;
        }
        else
        {
            recocu_adicao = null; // Limpa o valor se for inválido
        }

        // Atualiza o texto exibido no campo
        _recocu_adicao = text;

        OnBlurAdicao();
    }
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

    public string _Nome => recocu_numos == null ? " ** Receituário em DIGITAÇÃO ** " : $"Receituário Nº {recocu_numos}";

    public string _Lente { get; set; }



    #endregion

    public void AdicionarEmpresa(Empresas input)
    {
        recocu_emp_key = input.emp_key;
    }
    public int recocu_emp_key { get; set; }


    public int? recocu_cad_key { get; set; }
    public Cadastros Cadastros { get; set; } = new();
    public ClientesOtica ClientesOtica { get; set; } = new();
    public int? recocu_clioti_key { get; set; }


    public void AdicionarVendedores(List<Funcionarios> input)
    {
        Funcionarios.Clear();
        Funcionarios.AddRange(input.OrderBy(x => x.fun_nome));
    }
    public List<Funcionarios> Funcionarios { get; private set; } = new();
    public Funcionarios? Funcionario { get; set; } = null;
    public int? recocu_fun_key { get; set; }


    public void AdicionarTiposMateriais(List<TiposMateriais> input)
    {
        TiposMateriais.Clear();
        TiposMateriais.AddRange(input);
    }
    public List<TiposMateriais> TiposMateriais { get; private set; } = new();
    public TiposMateriais? TipoMateriais { get; set; } = null;


    public void AdicionarPrescritores(List<Prescritores> input)
    {
        Prescritores.Clear();
        Prescritores.AddRange(input.OrderBy(x => x.pre_nome));
    }
    public List<Prescritores> Prescritores { get; private set; } = new();
    public Prescritores? Prescritor { get; set; } = null;
    public int? recocu_pre_key { get; set; }


    public List<ReceituarioOculosAnexos>? ReceituarioOculosAnexos { get; set; } = null;
    public List<ReceituarioOculosArmacao>? ReceituarioOculosArmacao { get; set; } = null;
    public List<ReceituarioOculosArmacaoMaterial>? ReceituarioOculosArmacaoMaterial { get; set; } = null;



}
