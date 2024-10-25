using PSMobile.core.Entities;

using System.Text.Json.Serialization;

namespace PSMobile.core.InputModel;

public class OrdensServicosInputModel : PSMobile.core.Entities.InputModel
{
    public OrdensServicosInputModel() { }
    public OrdensServicosInputModel(int emp_key)
    {
        _ordser_emp_key = emp_key;
    }

    [JsonIgnore] public Cadastros? Cliente { get; set; } = new();
    [JsonIgnore] public Funcionarios? Funcionario { get; set; } = new();
    [JsonIgnore] public OrdensServicos? CurrentOS { get; set; } = new();
    [JsonIgnore] public bool HasClient => Cliente.cad_key == 0 ? false : true;

    public string OSNome => _ordser_numero == 0 ? "O.S." : $"O.S. Nº:{_ordser_numero}";

    public int _ordser_key { get; set; }
    public int _ordser_numero { get; set; }
    public int _ordser_emp_key { get; set; }
    public int _ordser_cad_key { get; set; }
    public string _ordser_comput { get; set; } = "API PSMobile";
    public int _ordser_usu { get; set; } = 0;
    public int? _ordser_fun_key { get; set; } = null;
    public string _ordser_obs { get; set; } = string.Empty;
    public string? _ordser_placa { get; set; }
    public string? _ordser_faturamento { get; set; }
    public string? _ordser_cnpj { get; set; }
    public string? _ordser_fone { get; set; }
    public string? _ordser_nome { get; set; } = "(SEM CLIENTE DEFINIDO...)";
    public DateTime? _ordser_datapre { get; set; }
    public DateTime? _ordser_dataenv { get; set; }
    public DateTime? _ordser_dataret { get; set; }
    public DateTime? _ordser_dataent { get; set; }
    public DateTime? _ordser_data { get; set; }
    public int _ordser_tabelacusto { get; set; }


    [JsonIgnore] public decimal TotalOS => CurrentOS?.OrdensServicosItens?.Sum(t => t.ordserite_total) ?? 0;
    [JsonIgnore] public decimal TotalOSComDesconto => CalcularVlrFinalComDesconto() ?? 0;
    [JsonIgnore] public bool DimissEdit => CurrentOS.ordser_finalizado == 1;


    private decimal? CalcularVlrFinalComDesconto()
    {
        var descontoEmReais = DescontoReais ?? 0;

        if (descontoEmReais > 0)
            return TotalOS - descontoEmReais;

        var descontoEmPercentual = DescontoPercentual ?? 0;

        if (descontoEmReais == 0 && descontoEmPercentual == 0)
            return TotalOS;

        var ret = TotalOS - (TotalOS * DescontoPercentual / 100);
        return ret;
    }

    [JsonIgnore] public decimal? DescontoReais { get; set; }
    [JsonIgnore] public decimal? DescontoPercentual { get; set; }
    [JsonIgnore] public bool CanFinish => CurrentOS.OrdensServicosItens.Count > 0;
}

