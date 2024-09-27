using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.infrastructure.Repositories;

public class PedidosRepository : ReadRepository<Pedidos>, IPedidosRepository
{
    private readonly AppDbContext _context;
    public PedidosRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    object DBNullOrValue<T>(T? value) where T : struct => value.HasValue ? (object)value.Value : DBNull.Value;
    object DBNullOrValue(string? value) => value ?? (object)DBNull.Value;
    public async Task<PedidosGravarRetornoFuncao> GravarAsync(PedidoInputModel entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        try
        {
            var parameters = new[]
            {
                new NpgsqlParameter("_ped_numero", DbType.Int32) { Value = entity._ped_numero },
                new NpgsqlParameter("_ped_emp_key", DbType.Int32) { Value = entity._ped_emp_key },
                new NpgsqlParameter("_ped_cad_key", DbType.Int32) { Value = DBNullOrValue( entity._ped_cad_key) },
                new NpgsqlParameter("_ped_comput", DbType.String) { Value = entity._ped_comput },
                new NpgsqlParameter("_ped_usu", DbType.Int32) { Value = entity._ped_usu },
                new NpgsqlParameter("_ped_fun_key", DbType.Int32) { Value = DBNullOrValue( entity._ped_fun_key) },
                new NpgsqlParameter("_ped_obs", DbType.String) { Value = entity._ped_obs },
                new NpgsqlParameter("_ped_nome", DbType.String) { Value = entity._ped_nome },
                new NpgsqlParameter("_ped_frete", DbType.Decimal) { Value = entity._ped_frete },
                new NpgsqlParameter("_ped_tabelacusto", DbType.Int32) { Value = entity._ped_tabelacusto },
                new NpgsqlParameter("_ped_dataent", DbType.Date) { Value = DBNullOrValue(entity._ped_dataent) },
            };

            var exec = await _context.Database.SqlQueryRaw<string>(
            @"
            SELECT public.pedidos_gravar(
                            @_ped_numero ,
	                        @_ped_emp_key ,
	                        @_ped_cad_key ,
	                        @_ped_comput ,
	                        @_ped_usu ,
	                        @_ped_fun_key ,
	                        @_ped_obs ,
	                        @_ped_nome ,
	                        @_ped_frete ,
	                        @_ped_tabelacusto ,
	                        @_ped_dataent 
                        )",
            parameters).ToListAsync();

            return new PedidosGravarRetornoFuncao(exec.FirstOrDefault());
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar cliente: {ex.Message}", ex);
        }
    }

}
