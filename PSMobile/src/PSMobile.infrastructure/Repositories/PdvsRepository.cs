using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class PdvsRepository : ReadRepository<Pdvs>, IPdvsRepository
{
    public PdvsRepository(AppDbContext context)
        : base(context) { }
}