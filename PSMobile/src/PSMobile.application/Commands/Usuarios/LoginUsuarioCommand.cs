using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace PSMobile.application.Commands.Usuarios;
public class LoginUsuarioCommand : IRequest<Dictionary<string, object>>
{
    public LoginUsuarioCommand(string usu_login, string usu_Senha)
    {
        Usu_login = usu_login;
        Usu_Senha = usu_Senha;
    }

    public string Usu_login { get; private set; }
    public string Usu_Senha { get; private set; }
}
