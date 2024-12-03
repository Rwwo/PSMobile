using PSMobile.core.Entities;
using PSMobile.core.ViewModel;
using PSMobile.SharedKernel.Utilities.Services;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IUsuariosService : IBaseReadServiceWithEmpKey<Usuarios>
{
    Task<Result<LoginViewModel>> Login(string usu_nome, string usu_senha);
}