using Microsoft.JSInterop;

using static MudBlazor.CategoryTypes;

namespace PSMobile.SharedKernel.Utilities.Handler;
public class JwtAuthorizationHandler : DelegatingHandler
{
    private readonly TokenService _tokenService;

    public JwtAuthorizationHandler(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(_tokenService.JwtToken))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _tokenService.JwtToken);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
