using System.ComponentModel;

namespace PSMobile.core.Enums;

public enum TipoVenda
{
    [Description("Venda para Consumidor Final / Uso e Consumo")]
    VendaParaConsumidorFinal_UsoEConsumo = 1,
    
    [Description("Venda para Revendedor - Revenda")]
    VendaParaRevendedor_Revenda= 0,
}
