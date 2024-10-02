﻿using System.Text.Json.Serialization;

using PSMobile.core.Entities;
using PSMobile.core.Enums;
using PSMobile.core.Extensions;

namespace PSMobile.core.InputModel;
public class PedidoInputModel : PSMobile.core.Entities.InputModel
{
    public PedidoInputModel() { }
    public PedidoInputModel(int ped_emp_key)
    {
        _ped_emp_key = ped_emp_key;
    }

    public (bool, List<string>) IsClientInvalid => Cliente.ValidarClienteParaEmissaoDeNFE();

    [JsonIgnore]
    public Cadastros Cliente { get; set; } = new();
    
    [JsonIgnore]
    public Funcionarios Funcionario { get; set; } = new();

    [JsonIgnore]
    public Pedidos? CurrentPedido { get; set; } = new();

    [JsonIgnore]
    public ICollection<PedidosFormasPagamento>? PedidosFormasPagamento { get; set; } = new List<PedidosFormasPagamento>();

    public bool HasClient => Cliente.cad_key == 0 ? false : true;
    public bool ClientIsContribuinte => HasClient && !string.IsNullOrEmpty(Cliente.cad_ie) ? true : false;
    public string PedidoNome => _ped_numero == 0 ? "Pedido" : $"Pedido {_ped_numero}";
    public int? _ped_key { get; set; } = null;
    public int _ped_numero { get; set; }
    public int _ped_emp_key { get; set; }
    public int? _ped_cad_key => Cliente.cad_key != 0 ? Cliente.cad_key : null;
    public string _ped_comput { get; set; } = "API PSMobile";
    public int _ped_usu { get; set; } = 0;
    public int? _ped_fun_key => Funcionario.fun_key != 0 ? Funcionario.fun_key : null;
    public string _ped_obs { get; set; } = "";
    public string _ped_nome => Cliente.cad_key != 0 ? Cliente.cad_nome : "(SEM CLIENTE DEFINIDO...)";
    public decimal _ped_frete { get; set; } = 0;
    public int _ped_tabelacusto { get; set; } = 0;
    public DateTime? _ped_dataent { get; set; } = null;

    public TipoDoc _ped_tipodocemitir { get; set; } = TipoDoc.NFCe;
    public TipoRetirada _ped_retira { get; set; } = TipoRetirada.EntregaNoCliente;
    public TipoVenda _ped_iddest { get; set; } = TipoVenda.VendaParaConsumidorFinal_UsoEConsumo;
    public int _ped_consumidorfinal { get; set; } = 0;

    public decimal TotalPedido => CurrentPedido?.PedidosItens?.Sum(t => t.pedite_total) ?? 0;
    public decimal TotalPedidoComDesconto => CalcularVlrFinalPedidoComDesconto() ?? 0;

    public decimal? CalcularVlrFinalPedidoComDesconto()
    {
        var descontoEmReais = DescontoReais ?? 0;

        if (descontoEmReais > 0)
            return TotalPedido - descontoEmReais;

        var descontoEmPercentual = DescontoPercentual ?? 0;

        if (descontoEmReais == 0 && descontoEmPercentual == 0)
            return TotalPedido;

        var ret = TotalPedido - (TotalPedido * DescontoPercentual / 100);
        return ret;
    }
    public decimal? DescontoReais { get; set; }
    public decimal? DescontoPercentual { get; set; }
    public decimal SaldoRestante => CalcularSaldoRestante();

    public bool CanFinish => SaldoRestante == 0;
    private decimal CalcularSaldoRestante()
    {
        var list = CurrentPedido?.PedidosFormasPagamento;

        if (list is null)
            return TotalPedidoComDesconto;

        return TotalPedidoComDesconto - (CurrentPedido?.PedidosFormasPagamento?.Sum(t => t.pedforpag_valor) ?? 0);
    }
}
