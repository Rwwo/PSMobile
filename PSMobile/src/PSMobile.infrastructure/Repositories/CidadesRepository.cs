using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class CidadesRepository : Repository<Cidades>, ICidadesRepository
{
    public CidadesRepository(AppDbContext context)
        : base(context) { }
}
