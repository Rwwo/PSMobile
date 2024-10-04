using PSMobile.core.Enums;

namespace PSMobile.core.InputModel;

public class PedidoAtualizarInputModel : PSMobile.core.Entities.InputModel
{
    public int _ped_emp_key { get; set; } = 0;
    public int _ped_numero { get; set; } = 0;
    public int _ped_finalizado { get; set; } = 0;
    public TipoDoc _ped_tipodocemitir { get; set; } = TipoDoc.NFCe;
    public TipoRetirada _ped_retira { get; set; } = TipoRetirada.EntregaNoCliente;
    public TipoVenda _ped_iddest { get; set; } = TipoVenda.VendaParaConsumidorFinal_UsoEConsumo;
    public int _ped_consumidorfinal { get; set; } = 0;
}
