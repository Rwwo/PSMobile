using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;
using PSMobile.core.InputModel;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.infrastructure.Repositories;

public class OrdensServicosRepository : ReadRepository<OrdensServicos>, IOrdensServicosRepository
{
    private readonly AppDbContext _context;
    public OrdensServicosRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    object DBNullOrValue<T>(T? value) where T : struct => value.HasValue ? (object)value.Value : DBNull.Value;
    object DBNullOrValue(string? value) => value ?? (object)DBNull.Value;
    public async Task<OrdensServicoGravarRetornoFuncao> GravarAsync(OrdensServicosInputModel entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        try
        {
            var parameters = new[]
            {
                new NpgsqlParameter("_ordser_numero", DbType.Int32)         { Value = entity._ordser_numero },
                new NpgsqlParameter("_ordser_emp_key", DbType.Int32)        { Value = entity._ordser_emp_key },
                new NpgsqlParameter("_ordser_cad_key", DbType.Int32)        { Value =  entity._ordser_cad_key },
                new NpgsqlParameter("_ordser_comput", DbType.String)        { Value = entity._ordser_comput },
                new NpgsqlParameter("_ordser_usu", DbType.Int32)            { Value = entity._ordser_usu },
                new NpgsqlParameter("_ordser_fun_key", DbType.Int32)        { Value =  DBNullOrValue(entity._ordser_fun_key) },
                new NpgsqlParameter("_ordser_obs", DbType.String)           { Value = entity._ordser_obs },
                new NpgsqlParameter("_ordser_placa", DbType.String)         { Value = DBNullOrValue(entity._ordser_placa) },
                new NpgsqlParameter("_ordser_faturamento", DbType.String)   { Value = DBNullOrValue(entity._ordser_faturamento) },
                new NpgsqlParameter("_ordser_cnpj", DbType.String)          { Value = DBNullOrValue(entity._ordser_cnpj) },
                new NpgsqlParameter("_ordser_fone", DbType.String)          { Value = DBNullOrValue(entity._ordser_fone) },
                new NpgsqlParameter("_ordser_nome", DbType.String)          { Value = DBNullOrValue(entity._ordser_nome) },
                new NpgsqlParameter("_ordser_datapre", DbType.Date)         { Value = DBNullOrValue(entity._ordser_datapre) },
                new NpgsqlParameter("_ordser_dataenv", DbType.Date)         { Value = DBNullOrValue(entity._ordser_dataenv) },
                new NpgsqlParameter("_ordser_dataret", DbType.Date)         { Value = DBNullOrValue(entity._ordser_dataret) },
                new NpgsqlParameter("_ordser_dataent", DbType.Date)         { Value = DBNullOrValue(entity._ordser_dataent) },
                new NpgsqlParameter("_ordser_data", DbType.Date)            { Value = DBNullOrValue(entity._ordser_data) },
                new NpgsqlParameter("_ordser_tabelacusto", DbType.Int32)    { Value = entity._ordser_tabelacusto },
            };

            var exec = await _context.Database.SqlQueryRaw<string>(
            @"
                    SELECT public.ordensservicos_gravar(
	                     @_ordser_numero 
	                    ,@_ordser_emp_key 
	                    ,@_ordser_cad_key 
	                    ,@_ordser_comput 
	                    ,@_ordser_usu 
	                    ,@_ordser_fun_key 
	                    ,@_ordser_obs 
	                    ,@_ordser_placa 
	                    ,@_ordser_faturamento 
	                    ,@_ordser_cnpj 
	                    ,@_ordser_fone 
	                    ,@_ordser_nome 
	                    ,@_ordser_datapre 
	                    ,@_ordser_dataenv 
	                    ,@_ordser_dataret 
	                    ,@_ordser_dataent 
	                    ,@_ordser_data 
	                    ,@_ordser_tabelacusto 
                        )",
            parameters).ToListAsync();

            return new OrdensServicoGravarRetornoFuncao(exec.FirstOrDefault());
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar cliente: {ex.Message}", ex);
        }
    }

    public async Task<OrdensServicoGravarRetornoFuncao> AtualizarAsync(OrdensServicosInputModel entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        try
        {


            return new OrdensServicoGravarRetornoFuncao("0|0");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar cliente: {ex.Message}", ex);
        }
    }
}