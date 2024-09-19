using PSMobile.core.Entities;
using PSMobile.core.Interfaces;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class FuncionariosRepository : Repository<Funcionarios>, IFuncionariosRepository
{
    public FuncionariosRepository(AppDbContext context)
        : base(context) { }
}
