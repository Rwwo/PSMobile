using PSMobile.core.Entities;

namespace PSMobile.core.ViewModel;
public class LoginViewModel
{
    public LoginViewModel(Usuarios usuario, string token)
    {
        Usuario = usuario;
        Token = token;
    }

    public Usuarios Usuario { get; private set; }
    public string Token { get; private  set; }

}

public class JwtConfig
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public int ExpireMinutes { get; set; }
}
