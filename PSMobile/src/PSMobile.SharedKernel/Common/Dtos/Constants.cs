using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PSMobile.SharedKernel.Common.Dtos;
public static class Constants
{
    public const string AuthScheme = "ap-auth";
    public const string AuthCookie = "ap-auth";
}
public record LoggedInUserModel(int Id, string Name, string Email)
{
    public Claim[] ToClaims() =>
        [
            new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
            new Claim(ClaimTypes.Name, Name),
            new Claim(ClaimTypes.Email, Email),
        ];
}
