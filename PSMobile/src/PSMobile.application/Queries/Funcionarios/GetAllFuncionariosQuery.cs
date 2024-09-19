using MediatR;

namespace PSMobile.application.Queries.Funcionarios;

public class GetAllFuncionariosQuery : IRequest<List<core.Entities.Funcionarios>>
{
}
