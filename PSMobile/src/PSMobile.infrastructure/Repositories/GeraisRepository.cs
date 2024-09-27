using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class GeraisRepository : ReadRepository<Gerais>, IGeraisRepository
{
    public GeraisRepository(AppDbContext context)
        : base(context) { }
}
