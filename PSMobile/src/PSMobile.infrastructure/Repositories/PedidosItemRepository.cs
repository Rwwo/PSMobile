using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;
using MediatR;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.infrastructure.Repositories;

public class PedidosItemRepository : ReadRepository<PedidosItens>, IPedidosItemRepository
{
    private readonly AppDbContext _context;
    public PedidosItemRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    object DBNullOrValue<T>(T? value) where T : struct => value.HasValue ? (object)value.Value : DBNull.Value;
    object DBNullOrValue(string? value) => value ?? (object)DBNull.Value;
    public async Task<PedidosItemGravarRetornoFuncao> GravarAsync(PedidoItemInputModel entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        try
        {
            var parameters = new[]
            {
                new NpgsqlParameter("_pedite_ped_key"       , DbType.Int32)   { Value = entity._pedite_ped_key },
                new NpgsqlParameter("_item"                 , DbType.Int32)   { Value = entity._item },
                new NpgsqlParameter("_pedite_pro_codigo"    , DbType.String)  { Value = entity._pedite_pro_codigo },
                new NpgsqlParameter("_pedite_valorunitario" , DbType.Decimal) { Value = entity._pedite_valorunitario },
                new NpgsqlParameter("_pedite_desconto"      , DbType.Decimal) { Value = entity._pedite_desconto },
                new NpgsqlParameter("_pedite_subtotal"      , DbType.Decimal) { Value = entity._pedite_subtotal },
                new NpgsqlParameter("_pedite_qtd"           , DbType.Decimal) { Value = entity._pedite_qtd },
                new NpgsqlParameter("_pedite_total"         , DbType.Decimal) { Value = entity._pedite_total },
                new NpgsqlParameter("_pedite_nome"          , DbType.String)  { Value = DBNullOrValue(entity._pedite_nome) },
                new NpgsqlParameter("_pedite_fun_key"       , DbType.Int32)   { Value = DBNullOrValue(entity._pedite_fun_key) },
                new NpgsqlParameter("_usu"                  , DbType.Int32)   { Value = 0 },
                new NpgsqlParameter("_comput"               , DbType.String)  { Value = "API PSMobile" },
                new NpgsqlParameter("_custo"                , DbType.Decimal) { Value = 0 },
                new NpgsqlParameter("_pro_nome"             , DbType.String)  { Value = DBNullOrValue(entity._pedite_nome) },
                new NpgsqlParameter("_emp_key"              , DbType.Int32)   { Value = entity._emp_key },
                new NpgsqlParameter("_justificativa"        , DbType.String)  { Value = DBNullOrValue(entity._justificativa) },
                new NpgsqlParameter("_pedite_lote"          , DbType.String)  { Value = DBNullOrValue(entity._pedite_lote) },
                new NpgsqlParameter("_pedite_datafab"       , DbType.Date)    { Value = DBNullOrValue(entity._pedite_datafab) },
                new NpgsqlParameter("_pedite_dataval"       , DbType.Date)    { Value = DBNullOrValue(entity._pedite_dataval) },

            };

            var ret = await _context.Database.SqlQueryRaw<int>(
                @"
                SELECT public.pedidositens_gravar(
	                @_pedite_ped_key,
	                @_item,
	                @_pedite_pro_codigo,
	                @_pedite_valorunitario,
	                @_pedite_desconto,
	                @_pedite_subtotal,
	                @_pedite_qtd,
	                @_pedite_total,
	                @_pedite_nome,
	                @_pedite_fun_key,
	                @_usu,
	                @_comput,
	                @_custo,
	                @_pro_nome,
	                @_emp_key,
	                @_justificativa,
	                @_pedite_lote,
	                @_pedite_datafab,
	                @_pedite_dataval
                )",
                parameters).ToListAsync();

            return new PedidosItemGravarRetornoFuncao(ret.FirstOrDefault());
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar item do pedido: {ex.Message}", ex);
        }
    }
    public async Task DeleteAsync(int entity_key)
    {

        try
        {
            var parameters = new[]
            {
                new NpgsqlParameter("_pedite_key", DbType.Int32){ Value = entity_key }
            };

            var ret = await _context.Database.SqlQueryRaw<int>(
                @"
                SELECT public.pedidositens_excluir(
	                @_pedite_key
                )",
                parameters).ToListAsync();

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar item do pedido: {ex.Message}", ex);
        }
    }
}
