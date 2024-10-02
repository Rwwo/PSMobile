using System.ComponentModel;

namespace PSMobile.core.Enums;

public enum TipoRetirada
{
    [Description(description: "Entrega no Endereço do Cliente")]
    EntregaNoCliente = 0,

    [Description("Retira na Empresa")]
    RetiraNaLoja = 1,
}
