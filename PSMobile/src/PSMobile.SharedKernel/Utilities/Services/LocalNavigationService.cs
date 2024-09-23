using PSMobile.core.Entities;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class LocalNavigationService : ILocalNavigationService
{
    public Cadastros? Cadastro { get; private set; } = null;

    
    public void SetarCliente(Cadastros? input) => Cadastro = input;
    public void LimparCliente() => Cadastro = null;
}