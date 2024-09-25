using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class LocalNavigationService : ILocalNavigationService
{
    public PaginatedResult<Gerais> Gerais { get; set; } = null!;
    public void SetarGerais(PaginatedResult<Gerais>? input) => Gerais = input;


    public Pedidos? Pedido { get; private set; } = null;
    public void SetarPedido(Pedidos? input) => Pedido = input;
    public void LimparPedido() => Pedido = null;


    public Cadastros? Cadastro { get; private set; } = null;
    public void SetarCliente(Cadastros? input) => Cadastro = input;
    public void LimparCliente() => Cadastro = null;
}