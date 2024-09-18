using PSMobile.core.Entities;

namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IApiService
{
    Task<List<Cidades>> CidadesGetAllAsync();
}