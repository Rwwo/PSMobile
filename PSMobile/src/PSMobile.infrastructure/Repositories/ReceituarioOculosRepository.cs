using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class ReceituarioOculosRepository : ReadRepository<ReceituarioOculos>, IReceituarioOculosRepository
{
    public ReceituarioOculosRepository(AppDbContext context)
        : base(context) { }
}
