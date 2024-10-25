using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class LocalNavigationService : ILocalNavigationService
{
    public Empresas EmpresaAtual { get; set; }
    public PaginatedResult<Gerais> Gerais { get; set; } = null!;
    public void SetarGerais(PaginatedResult<Gerais> input)
    {
        Gerais = input;

        if (Gerais?.Items.Count > 0)
            EmpresaAtual = Gerais.Items[0].Empresa;

    }


    public OrdensServicos? OrdemServico { get; private set; } = null;
    public void SetarOS(OrdensServicos? input) => OrdemServico = input;
    public void LimparOS() => OrdemServico = null;


    public Pedidos? Pedido { get; private set; } = null;
    public void SetarPedido(Pedidos? input) => Pedido = input;
    public void LimparPedido() => Pedido = null;


    public Cadastros? Cadastro { get; private set; } = null;

    public void SetarCliente(Cadastros? input) => Cadastro = input;
    public void LimparCliente() => Cadastro = null;
}