using AutoMapper;

using MediatR;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.core.Notifications;
using PSMobile.core.Services;
using PSMobile.core.ViewModel;

namespace PSMobile.application.Commands.Usuarios;

public class LoginUsuarioCommandHandler : BaseService, IRequestHandler<LoginUsuarioCommand, LoginViewModel>
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public LoginUsuarioCommandHandler(IAuthService authService, IUnitOfWork uow, IMapper mapper, INotificador notificador)
        : base(notificador)
    {
        _authService = authService;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<LoginViewModel> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
    {

        var retornoLogin = await _uow.UsuariosRepository.GetAuthentication(request.Usu_nome, request.Usu_Senha);

        if (!retornoLogin.Item1)
        {
            Notificar("Usuário não encontrado");
            return null;
        }

        var token = _authService.GenerateJwtToken(retornoLogin.Item2);

        var result = new LoginViewModel(retornoLogin.Item2, token);

        return result;
    }
}