using MediatR;

namespace PSMobile.application.Queries.Cidades;
public class GetAllCidadesQuery : IRequest<List<core.Entities.Cidades>>
{
}
