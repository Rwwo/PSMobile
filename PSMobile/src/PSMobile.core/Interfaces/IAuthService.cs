using PSMobile.core.Entities;

namespace PSMobile.core.Interfaces;

public interface IAuthService
{
    string GenerateJwtToken(Usuarios userDB);
    string ComputeSha256Hash(string password);
}