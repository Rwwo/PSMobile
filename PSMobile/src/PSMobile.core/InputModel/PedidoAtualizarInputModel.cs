namespace PSMobile.core.InputModel;

public class PedidoAtualizarInputModel : PSMobile.core.Entities.InputModel
{
    public int _ped_emp_key { get; set; } = 0;
    public int _ped_numero { get; set; } = 0;
    public int _ped_tipodocemitir { get; set; } = 0;
    public int _ped_retira { get; set; } = 0;
    public int _ped_iddest { get; set; } = 0;
    public int _ped_consumidorfinal { get; set; } = 0;
}
