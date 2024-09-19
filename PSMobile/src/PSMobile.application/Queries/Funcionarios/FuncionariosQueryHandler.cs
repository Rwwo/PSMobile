﻿
using System.Linq.Expressions;

using AutoMapper;

using MediatR;

using PSMobile.core.Interfaces;

namespace PSMobile.application.Queries.Funcionarios;

public class FuncionariosQueryHandler
    : IRequestHandler<GetAllFuncionariosQuery, List<core.Entities.Funcionarios>>
    , IRequestHandler<GetFuncionariosByNomeQuery, List<core.Entities.Funcionarios>>
    , IRequestHandler<GetFuncionarioByKeyQuery, core.Entities.Funcionarios>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;

    public FuncionariosQueryHandler(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<List<core.Entities.Funcionarios>> Handle(GetFuncionariosByNomeQuery request, CancellationToken cancellationToken)
    {
        // Ajusta o filtro para garantir a comparação insensível a maiúsculas e minúsculas
        Expression<Func<core.Entities.Funcionarios, bool>> filtro = c => c.fun_nome.ToLower().Contains(request.PartialName.ToLower());

        return await _uow.FuncionariosRepository.GetAllAsync(filtro);
    }

    public async Task<List<core.Entities.Funcionarios>> Handle(GetAllFuncionariosQuery request, CancellationToken cancellationToken)
    {
        return await _uow.FuncionariosRepository.GetAllAsync();
    }

    public async Task<core.Entities.Funcionarios> Handle(GetFuncionarioByKeyQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<core.Entities.Funcionarios, bool>> filtro = c => c.fun_key == request.FunKey;
        return await _uow.FuncionariosRepository.GetByIdAsync(filtro);
    }
}
