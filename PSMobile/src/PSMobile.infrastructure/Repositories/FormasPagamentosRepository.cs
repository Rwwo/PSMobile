using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class FormasPagamentosRepository : ReadRepository<FormasPagamento>, IFormasPagamentosRepository
{
    public FormasPagamentosRepository(AppDbContext context)
        : base(context) { }
}
