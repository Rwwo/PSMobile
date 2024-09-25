using PSMobile.core.Entities;
using PSMobile.infrastructure.Repositories;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface ILocalNavigationService
{
    PaginatedResult<Gerais>? Gerais { get; }
    void SetarGerais(PaginatedResult<Gerais>? input);

    Cadastros? Cadastro { get; }
    void LimparCliente();
    void SetarCliente(Cadastros? input);


    Pedidos? Pedido { get; }
    void LimparPedido();
    void SetarPedido(Pedidos? input);
}