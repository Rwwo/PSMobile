using PSMobile.core.Entities;

namespace PSMobile.SharedKernel.Common.Dtos.Extensions;

public static class PedidosInputModelExtensions
{
    public static Pedidos ToPedido(this PedidoInputModel pedido)
    {
        var ret = new Pedidos
        {
            ped_key = pedido.ped_key,
            ped_numero = pedido.ped_numero,
            ped_nome = pedido.ped_nome,
            ped_emp_key = pedido.ped_emp_key,
            ped_cad_key = pedido.ped_cad_key,
            ped_data = pedido.ped_data,
            ped_comput = pedido.ped_comput,
            ped_usu = pedido.ped_usu,
            ped_fun_key = pedido.ped_fun_key,
            ped_total = pedido.ped_total,
            ped_finalizado = pedido.ped_finalizado,
            ped_exc = pedido.ped_exc,
            ped_mov_key = pedido.ped_mov_key,
            ped_lancado = pedido.ped_lancado,
            ped_obs = pedido.ped_obs,
            ped_fone = pedido.ped_fone,
            ped_contato = pedido.ped_contato,
            ped_endereco = pedido.ped_endereco,
            ped_datalan = pedido.ped_datalan,
            ped_val_key_array = pedido.ped_val_key_array,
            ped_desconto = pedido.ped_desconto,
            ped_recpop_key = pedido.ped_recpop_key,
            ped_prepag_key_array = pedido.ped_prepag_key_array,
            ped_crm = pedido.ped_crm,
            ped_dataexc = pedido.ped_dataexc,
            ped_dataimp = pedido.ped_dataimp,
            ped_frete = pedido.ped_frete,
            ped_vinculado = pedido.ped_vinculado,
            ped_retira = pedido.ped_retira,
            ped_iddest = pedido.ped_iddest,
            ped_tipodocemitir = pedido.ped_tipodocemitir,
            ped_consumidorfinal = pedido.ped_consumidorfinal,
            ped_tabelacusto = pedido.ped_tabelacusto,
            ped_acrescimo = pedido.ped_acrescimo,
            ped_cad_key_pontos = pedido.ped_cad_key_pontos,
            ped_dataent = pedido.ped_dataent,
            ped_usu_criacao = pedido.ped_usu_criacao,
            ped_datafin = pedido.ped_datafin,
            ped_valoripi = pedido.ped_valoripi,
        };

        return ret;
    }
}

