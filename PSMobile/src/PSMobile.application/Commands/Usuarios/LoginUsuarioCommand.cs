using MediatR;

using PSMobile.core.ViewModel;

namespace PSMobile.application.Commands.Usuarios;
public class LoginUsuarioCommand : IRequest<LoginViewModel>
{
    public LoginUsuarioCommand(string usu_nome, string usu_senha)
    {
        Usu_nome = usu_nome;
        Usu_Senha = usu_senha;
    }

    public string Usu_nome { get; private set; }
    public string Usu_Senha { get; private set; }
}
