using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class TiposMateriaisRepository : ReadRepository<TiposMateriais>, ITiposMateriaisRepository
{
    public TiposMateriaisRepository(AppDbContext context)
        : base(context) { }
}