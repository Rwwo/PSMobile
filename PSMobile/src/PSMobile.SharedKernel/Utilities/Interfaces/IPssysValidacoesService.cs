using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IPssysValidacoesService
{
    bool IsCnpj(string cnpj);
    bool IsCpf(string cpf);
    string PSFormatarCNPJ(string _CPFouCNPJ);
    string PSFormatarFone(string Texto);
}