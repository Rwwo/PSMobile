using PSMobile.core.Entities;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface ILocalNavigationService
{
    Cadastros? Cadastro { get; }
    void SetarCliente(Cadastros input);
}
