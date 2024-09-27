using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using MediatR;
using PSMobile.core.ReturnFunctions;

namespace PSMobile.infrastructure.Repositories;

public class CadastroRepository : ReadRepository<Cadastros>, ICadastroRepository
{
    private readonly AppDbContext _context;
    public CadastroRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    object DBNullOrValue<T>(T? value) where T : struct => value.HasValue ? (object)value.Value : DBNull.Value;
    object DBNullOrValue(string? value) => value ?? (object)DBNull.Value;


    public async Task<ClienteGravarRetornoFuncao> GravarAsync(Cadastros entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        try
        {
            var parameters = new[]
            {
                new NpgsqlParameter("key", DbType.Int32) { Value = entity.cad_key },
                new NpgsqlParameter("cnpj", DbType.String) { Value = DBNullOrValue(entity.cad_cnpj) },
                new NpgsqlParameter("sexo", DbType.String) { Value = DBNullOrValue(entity.cad_sexo) },
                new NpgsqlParameter("nome", DbType.String) { Value = DBNullOrValue(entity.cad_nome) },
                new NpgsqlParameter("razao", DbType.String) { Value = DBNullOrValue(entity.cad_razao) },
                new NpgsqlParameter("ie", DbType.String) { Value = DBNullOrValue(entity.cad_ie) },
                new NpgsqlParameter("im", DbType.String) { Value = DBNullOrValue(entity.cad_im) },
                new NpgsqlParameter("ist", DbType.String) { Value = DBNullOrValue(entity.cad_ist) },
                new NpgsqlParameter("fone1", DbType.String) { Value = DBNullOrValue(entity.CadastroContato.cad_fone1) },
                new NpgsqlParameter("fone2", DbType.String) { Value = DBNullOrValue(entity.CadastroContato.cad_fone2) },
                new NpgsqlParameter("fone3", DbType.String) { Value = DBNullOrValue(entity.CadastroContato.cad_fone3) },
                new NpgsqlParameter("contato", DbType.String) { Value = DBNullOrValue(entity.CadastroContato.cad_contato) },
                new NpgsqlParameter("fonecontato", DbType.String) { Value = DBNullOrValue(entity.CadastroContato.cad_fonecontato) },
                new NpgsqlParameter("email", DbType.String) { Value = DBNullOrValue(entity.CadastroContato.cad_email) },
                new NpgsqlParameter("site", DbType.String) { Value = DBNullOrValue(entity.CadastroContato.cad_site) },
                new NpgsqlParameter("rg", DbType.String) { Value = DBNullOrValue(entity.cad_rg) },
                new NpgsqlParameter("orgao", DbType.String) { Value = DBNullOrValue(entity.cad_orgao) },
                new NpgsqlParameter("datanasfun", DbType.Date) { Value = DBNullOrValue(entity.cad_datanasfun) },
                new NpgsqlParameter("cli_datacad", DbType.Date) { Value = DBNullOrValue(entity.CadastroCliente.cad_cli_datacad) },
                new NpgsqlParameter("obs", DbType.String) { Value = DBNullOrValue(entity.cad_obs) },
                new NpgsqlParameter("cli_usu", DbType.Int32) { Value = 1 },
                new NpgsqlParameter("cli_comput", DbType.String) { Value = "API" },
                new NpgsqlParameter("cli_mensagem", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_limitetotal", DbType.Decimal) { Value = entity.CadastroCliente.CadastroCredito.cad_cli_limitetotal },
                new NpgsqlParameter("cli_limitemensal", DbType.Decimal) { Value = entity.CadastroCliente.CadastroCredito.cad_cli_limitemensal },
                new NpgsqlParameter("cli_limiteparcelas", DbType.Int32) { Value = entity.CadastroCliente.CadastroCredito.cad_cli_limiteparcelas },
                new NpgsqlParameter("cli_rendacomprovada", DbType.Decimal) { Value = entity.CadastroCliente.CadastroCredito.cad_cli_rendacomprovada },
                new NpgsqlParameter("cli_comprovanterenda", DbType.String) { Value = entity.CadastroCliente.CadastroCredito.cad_cli_comprovanterenda },
                new NpgsqlParameter("cli_renda", DbType.Decimal) { Value = entity.CadastroCliente.CadastroCredito.cad_cli_renda },
                new NpgsqlParameter("cli_ven_key", DbType.Int32) { Value = DBNull.Value },
                new NpgsqlParameter("cli_localtrabalho", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_cargo", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_fonetrabalho", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_ramaltrabalho", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_ref1", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_ref2", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_refban1", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_refban2", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_avaliador", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_dataava", DbType.Date) { Value = DBNull.Value },
                new NpgsqlParameter("cli_conjuge", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_datanasconjuge", DbType.Date) { Value = DBNull.Value },
                new NpgsqlParameter("cli_datacas", DbType.Date) { Value = DBNull.Value },
                new NpgsqlParameter("cli_pai", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_mae", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_naturalidade", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_grucli_key", DbType.Int32) { Value = DBNull.Value },
                new NpgsqlParameter("cli_estadocivil", DbType.Int32) { Value = DBNull.Value },
                new NpgsqlParameter("cli_admissao", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cli_bloqueado", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("cli_motivo", DbType.String) { Value = DBNull.Value },
                new NpgsqlParameter("cep", DbType.String) { Value = DBNullOrValue(entity.CadastroEndereco.cad_cep) },
                new NpgsqlParameter("endereco", DbType.String) { Value = DBNullOrValue(entity.CadastroEndereco.cad_endereco) },
                new NpgsqlParameter("numero", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEndereco.cad_numero) },
                new NpgsqlParameter("complemento", DbType.String) { Value = DBNullOrValue(entity.CadastroEndereco.cad_complemento) },
                new NpgsqlParameter("ufs_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEndereco.cad_ufs_codigo) },
                new NpgsqlParameter("cid_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEndereco.cad_cid_codigo) },
                new NpgsqlParameter("bairro", DbType.String) { Value = DBNullOrValue(entity.CadastroEndereco.cad_bairro) },
                new NpgsqlParameter("entcep", DbType.String) { Value = DBNullOrValue(entity.CadastroEnderecoEntrega.cad_cep) },
                new NpgsqlParameter("entendereco", DbType.String) { Value = DBNullOrValue(entity.CadastroEnderecoEntrega.cad_endereco) },
                new NpgsqlParameter("entnumero", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEnderecoEntrega.cad_numero) },
                new NpgsqlParameter("entcomplemento", DbType.String) { Value = DBNullOrValue(entity.CadastroEnderecoEntrega.cad_complemento) },
                new NpgsqlParameter("entufs_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEnderecoEntrega.cad_ufs_codigo) },
                new NpgsqlParameter("entcid_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEnderecoEntrega.cad_cid_codigo) },
                new NpgsqlParameter("entbairro", DbType.String) { Value = DBNullOrValue(entity.CadastroEnderecoEntrega.cad_bairro) },
                new NpgsqlParameter("corcep", DbType.String) { Value = DBNullOrValue(entity.CadastroEnderecoCorrespondencia.cad_cep) },
                new NpgsqlParameter("corendereco", DbType.String) { Value = DBNullOrValue(entity.CadastroEnderecoCorrespondencia.cad_endereco) },
                new NpgsqlParameter("cornumero", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEnderecoCorrespondencia.cad_numero) },
                new NpgsqlParameter("corcomplemento", DbType.String) { Value = DBNullOrValue(entity.CadastroEnderecoCorrespondencia.cad_complemento) },
                new NpgsqlParameter("corufs_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEnderecoCorrespondencia.cad_ufs_codigo) },
                new NpgsqlParameter("corcid_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEnderecoCorrespondencia.cad_cid_codigo) },
                new NpgsqlParameter("corbairro", DbType.String) { Value = DBNullOrValue(entity.CadastroEnderecoCorrespondencia.cad_bairro) },
                new NpgsqlParameter("preencherenderecos", DbType.Int32) { Value = 1 },
                new NpgsqlParameter("_cad_tipo", DbType.String) { Value = entity.cad_cnpj.Length > 14 ? "J" : "F" },
                new NpgsqlParameter("_cad_cli_diastolerancia", DbType.Int32) { Value = 1 },
                new NpgsqlParameter("_cad_cli_liberado", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("_cad_procli_key", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("_cad_cli_desconto", DbType.Decimal) { Value = entity.CadastroCliente.CadastroCredito.cad_cli_desconto },
                new NpgsqlParameter("_cad_cli_codigoextra", DbType.String) { Value = DBNullOrValue(null) },
                new NpgsqlParameter("_cad_cli_liberardescontos", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("_cad_cli_conv_key", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("_cad_pai_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEndereco.cad_pai_codigo) },
                new NpgsqlParameter("_cad_corpai_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEnderecoCorrespondencia.cad_pai_codigo) },
                new NpgsqlParameter("_cad_entpai_codigo", DbType.Int32) { Value = DBNullOrValue(entity.CadastroEnderecoEntrega.cad_pai_codigo) },

                new NpgsqlParameter("_cad_carfid_key", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("_cad_indicacaopresenca", DbType.Int32) { Value = 1 },
                new NpgsqlParameter("_cad_consumidorfinal", DbType.Int32) { Value =1 },
                new NpgsqlParameter("_cad_idestrangeiro", DbType.String) { Value = DBNullOrValue(null) },
                new NpgsqlParameter("_cad_apelido", DbType.String) { Value = DBNullOrValue(null) },
                new NpgsqlParameter("_cad_ufsemi_codigo", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("_cad_entreferencia", DbType.String) { Value = DBNullOrValue(null) },
                new NpgsqlParameter("_cad_cli_ven_fixo", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("_cad_tipoissqn", DbType.Int32) { Value = 1 },
                new NpgsqlParameter("_cad_referencia", DbType.String) { Value = DBNullOrValue(null) },
                new NpgsqlParameter("_cad_cli_dataval", DbType.Date) { Value = DBNullOrValue(null) },
                new NpgsqlParameter("_cad_cli_juros", DbType.Decimal) { Value = -2 },
                new NpgsqlParameter("_cad_cli_naocobrar", DbType.Int32) { Value = 0 },
                new NpgsqlParameter("_cad_ieisento", DbType.Int32) { Value = 0}
            };

            var ret = await _context.Database.ExecuteSqlRawAsync(
                @"SELECT public.clientes_gravar(
                    @key, 
                    @cnpj, 
                    @sexo, 
                    @nome, 
                    @razao, 
                    @ie, 
                    @im, 
                    @ist, 
                    @fone1, 
                    @fone2, 
                    @fone3, 
                    @contato, 
                    @fonecontato, 
                    @email, 
                    @site, 
                    @rg, 
                    @orgao, 
                    @datanasfun, 
                    @cli_datacad, 
                    @obs, 
                    @cli_usu, 
                    @cli_comput, 
                    @cli_mensagem, 
                    @cli_limitetotal, 
                    @cli_limitemensal, 
                    @cli_limiteparcelas, 
                    @cli_rendacomprovada, 
                    @cli_comprovanterenda, 
                    @cli_renda, 
                    @cli_ven_key, 
                    @cli_localtrabalho, 
                    @cli_cargo, 
                    @cli_fonetrabalho, 
                    @cli_ramaltrabalho, 
                    @cli_ref1, 
                    @cli_ref2, 
                    @cli_refban1, 
                    @cli_refban2, 
                    @cli_avaliador, 
                    @cli_dataava, 
                    @cli_conjuge, 
                    @cli_datanasconjuge, 
                    @cli_datacas, 
                    @cli_pai, 
                    @cli_mae, 
                    @cli_naturalidade, 
                    @cli_grucli_key, 
                    @cli_estadocivil, 
                    @cli_admissao, 
                    @cli_bloqueado, 
                    @cli_motivo, 
                    @cep, 
                    @endereco, 
                    @numero, 
                    @complemento, 
                    @ufs_codigo, 
                    @cid_codigo, 
                    @bairro, 
                    @entcep, 
                    @entendereco, 
                    @entnumero, 
                    @entcomplemento, 
                    @entufs_codigo, 
                    @entcid_codigo, 
                    @entbairro, 
                    @corcep, 
                    @corendereco, 
                    @cornumero, 
                    @corcomplemento, 
                    @corufs_codigo, 
                    @corcid_codigo, 
                    @corbairro, 
                    @preencherenderecos, 
                    @_cad_tipo, 
                    @_cad_cli_diastolerancia, 
                    @_cad_cli_liberado, 
                    @_cad_procli_key, 
                    @_cad_cli_desconto, 
                    @_cad_cli_codigoextra, 
                    @_cad_cli_liberardescontos, 
                    @_cad_cli_conv_key, 
                    @_cad_pai_codigo, 
                    @_cad_corpai_codigo, 
                    @_cad_entpai_codigo,
                    @_cad_carfid_key, 
                    @_cad_indicacaopresenca, 
                    @_cad_consumidorfinal, 
                    @_cad_idestrangeiro, 
                    @_cad_apelido, 
                    @_cad_ufsemi_codigo, 
                    @_cad_entreferencia, 
                    @_cad_cli_ven_fixo, 
                    @_cad_tipoissqn, 
                    @_cad_referencia, 
                    @_cad_cli_dataval, 
                    @_cad_cli_juros, 
                    @_cad_cli_naocobrar, 
                    @_cad_ieisento
                )",
                parameters);

            return new ClienteGravarRetornoFuncao(ret);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar cliente: {ex.Message}", ex);
        }
    }
}
