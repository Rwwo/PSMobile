using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class CidadesRepository : ReadRepository<Cidades>, ICidadesRepository
{
    public CidadesRepository(AppDbContext context)
        : base(context) { }
}

