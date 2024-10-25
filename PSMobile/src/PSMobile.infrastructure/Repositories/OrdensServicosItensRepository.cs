using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.infrastructure.Repositories;

public class OrdensServicosItensRepository : ReadRepository<OrdensServicosItens>, IOrdensServicosItensRepository
{
    private readonly AppDbContext _context;
    public OrdensServicosItensRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    object DBNullOrValue<T>(T? value) where T : struct => value.HasValue ? (object)value.Value : DBNull.Value;
    object DBNullOrValue(string? value) => value ?? (object)DBNull.Value;
    public async Task<OrdensServicosItensGravarRetornoFuncao> GravarAsync(OrdensServicosItensInputModel entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        try
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@_ordserite_ordser_key"   , DbType.Int32)    { Value = entity.@_ordserite_ordser_key },
                new NpgsqlParameter("@_item"                   , DbType.Int32)    { Value = entity.@_item },
                new NpgsqlParameter("@_ordserite_pro_codigo"   , DbType.String)   { Value = entity.@_ordserite_pro_codigo },
                new NpgsqlParameter("@_ordserite_valorunitario", DbType.Decimal)  { Value = entity.@_ordserite_valorunitario },
                new NpgsqlParameter("@_ordserite_desconto"     , DbType.Decimal)  { Value = entity.@_ordserite_desconto },
                new NpgsqlParameter("@_ordserite_subtotal"     , DbType.Decimal)  { Value = entity.@_ordserite_subtotal },
                new NpgsqlParameter("@_ordserite_qtd"          , DbType.Decimal)  { Value = entity.@_ordserite_qtd },
                new NpgsqlParameter("@_ordserite_total"        , DbType.Decimal)  { Value = entity.@_ordserite_total },
                new NpgsqlParameter("@_ordserite_nome"         , DbType.String)   { Value = entity.@_ordserite_nome },
                new NpgsqlParameter("@_ordserite_fun_key"      , DbType.Int32)    { Value = DBNullOrValue(entity.@_ordserite_fun_key) },
                new NpgsqlParameter("@_usu"                    , DbType.Int32)    { Value = entity.@_usu },
                new NpgsqlParameter("@_comput"                 , DbType.String)   { Value = entity.@_comput },
                new NpgsqlParameter("@_custo"                  , DbType.Decimal)  { Value = entity.@_custo },
                new NpgsqlParameter("@_pro_nome"               , DbType.String)   { Value = entity.@_pro_nome },
                new NpgsqlParameter("@_emp_key"                , DbType.Int32)    { Value = entity.@_emp_key },
                new NpgsqlParameter("@_justificativa"          , DbType.String)   { Value = entity.@_justificativa },
                new NpgsqlParameter("@_ordserite_lote"         , DbType.String)   { Value = DBNullOrValue(entity.@_ordserite_lote) },
                new NpgsqlParameter("@_ordserite_datafab"      , DbType.Date)     { Value = DBNullOrValue(entity.@_ordserite_datafab) },
                new NpgsqlParameter("@_ordserite_dataval"      , DbType.Date)     { Value = DBNullOrValue(entity.@_ordserite_dataval) },

            };

            var ret = await _context.Database.SqlQueryRaw<int>(
                @"
                SELECT public.ordensservicositens_gravar(
	                @_ordserite_ordser_key,
	                @_item,
	                @_ordserite_pro_codigo,
	                @_ordserite_valorunitario,
	                @_ordserite_desconto,
	                @_ordserite_subtotal,
	                @_ordserite_qtd,
	                @_ordserite_total,
	                @_ordserite_nome,
	                @_ordserite_fun_key,
	                @_usu,
	                @_comput,
	                @_custo,
	                @_pro_nome,
	                @_emp_key,
	                @_justificativa,
	                @_ordserite_lote,
	                @_ordserite_datafab,
	                @_ordserite_dataval
                )",
                parameters).ToListAsync();

            return new OrdensServicosItensGravarRetornoFuncao(ret.FirstOrDefault());
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
                new NpgsqlParameter("_ordserite_key", DbType.Int32){ Value = entity_key }
            };

            var ret = await _context.Database.SqlQueryRaw<int>(
                @"
                SELECT public.ordensservicositens_excluir(
	                @_ordserite_key
                )",
                parameters).ToListAsync();

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao Excluir item da OS: {ex.Message}", ex);
        }
    }
}
