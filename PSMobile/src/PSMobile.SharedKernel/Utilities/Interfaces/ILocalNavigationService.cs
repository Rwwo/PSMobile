using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface ILocalNavigationService
{
    Empresas EmpresaAtual { get; set; }
    PaginatedResult<Gerais> Gerais { get; }
    void SetarGerais(PaginatedResult<Gerais> input);

    Cadastros? Cadastro { get; }
    void LimparCliente();
    void SetarCliente(Cadastros? input);


    Pedidos? Pedido { get; }
    void LimparPedido();
    void SetarPedido(Pedidos? input);


    OrdensServicos? OrdemServico { get; }
    void LimparOS();
    void SetarOS(OrdensServicos? input);

    ReceituarioOculos? ReceituarioOculos { get; }
    void LimparReceituarioOtico();
    void SetarReceituarioOtico(ReceituarioOculos? input);
}