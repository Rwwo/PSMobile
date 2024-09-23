using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class UFsRepository : ReadRepository<Ufs>, IUFsRepository
{
    public UFsRepository(AppDbContext context)
        : base(context) { }
}

