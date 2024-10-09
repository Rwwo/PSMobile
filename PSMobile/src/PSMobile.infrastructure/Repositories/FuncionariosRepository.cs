using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class FuncionariosRepository : ReadRepository<Funcionarios>, IFuncionariosRepository
{
    public FuncionariosRepository(AppDbContext context)
        : base(context) { }
}
