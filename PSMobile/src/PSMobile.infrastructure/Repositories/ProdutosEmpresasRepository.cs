using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.core.Services;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class ProdutosEmpresasRepository : ReadRepository<ProdutosEmpresas>, IProdutosEmpresasRepository
{
    public ProdutosEmpresasRepository(AppDbContext context)
        : base(context) { }
}
