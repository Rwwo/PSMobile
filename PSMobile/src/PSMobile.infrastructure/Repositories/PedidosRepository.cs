using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

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
    public async Task<Pedidos> GravarAsync(Pedidos entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        try
        {
            var parameters = new[]
            {
                new NpgsqlParameter("_ped_numero", DbType.Int32) { Value = entity.ped_numero },
                new NpgsqlParameter("_ped_emp_key", DbType.Int32) { Value = entity.ped_emp_key },
                new NpgsqlParameter("_ped_cad_key", DbType.Int32) { Value = entity.ped_cad_key },
                new NpgsqlParameter("_ped_comput", DbType.String) { Value = DBNullOrValue(entity.ped_comput) },
                new NpgsqlParameter("_ped_usu", DbType.Int32) { Value = entity.ped_usu },
                new NpgsqlParameter("_ped_fun_key", DbType.Int32) { Value = entity.ped_fun_key },
                new NpgsqlParameter("_ped_obs", DbType.String) { Value = DBNullOrValue(entity.ped_obs) },
                new NpgsqlParameter("_ped_nome", DbType.String) { Value = DBNullOrValue(entity.ped_nome) },
                new NpgsqlParameter("_ped_frete", DbType.Decimal) { Value = entity.ped_frete },
                new NpgsqlParameter("_ped_tabelacusto", DbType.Int32) { Value = entity.ped_tabelacusto },
                new NpgsqlParameter("_ped_dataent", DbType.Date) { Value = DBNullOrValue(entity.ped_dataent) },
            };

            await _context.Database.ExecuteSqlRawAsync(
                @"SELECT public.pedidos_gravar(
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
                parameters);

            return entity;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar cliente: {ex.Message}", ex);
        }
    }
}
