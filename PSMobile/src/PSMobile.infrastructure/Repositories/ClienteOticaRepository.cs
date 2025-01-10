using Microsoft.EntityFrameworkCore;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class ClienteOticaRepository : ReadRepository<ClientesOtica>, IClienteOticaRepository
{
    private readonly AppDbContext _context;
    public ClienteOticaRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<ClienteOticaGravarRetornoFuncao> GravarAsync(ClienteOticaInputModel model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));

        try
        {

            var builder = new ClientesOticaBuilder();

            builder.ComDadosPessoais(model.clioti_nome, model.clioti_cpf, model.clioti_endereco, model.clioti_complemento, model.clioti_cad_key);

            builder.ComNumerosContatos(model.clioti_fone1, model.clioti_whats1 == true ? (short)1 : (short)0,
                                       model.clioti_fone2, model.clioti_whats2 == true ? (short)1 : (short)0,
                                       model.clioti_fone3, model.clioti_whats3 == true ? (short)1 : (short)0);


            var entity = builder.Builder();

            if (model.clioti_key == 0)
            {
                await _context.ClientesOtica.AddAsync(entity);
            }
            else
            {
                _context.ClientesOtica.Update(entity);
            }

            await _context.SaveChangesAsync();

            await AtualizarNomeTokensAsync(entity);

            return new ClienteOticaGravarRetornoFuncao(entity.clioti_key);
        }
        catch (DbUpdateException dbEx)
        {
            throw new InvalidOperationException("Erro ao salvar os dados no banco.", dbEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar cliente: {ex.Message}", ex);
        }
    }

    private async Task AtualizarNomeTokensAsync(ClientesOtica model)
    {
        if (string.IsNullOrWhiteSpace(model.clioti_nome))
            return;

        string query = @"
            UPDATE clientesotica 
            SET CLIOTI_NOME_TOKENS = to_tsvector({0}) 
            WHERE clioti_key = {1}";

        await _context.Database.ExecuteSqlRawAsync(query, model.clioti_nome, model.clioti_key);
    }
}

