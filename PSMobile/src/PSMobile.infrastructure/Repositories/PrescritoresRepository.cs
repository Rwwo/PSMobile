using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class PrescritoresRepository : ReadRepository<Prescritores>, IPrescritoresRepository
{
    public PrescritoresRepository(AppDbContext context)
        : base(context) { }

}
