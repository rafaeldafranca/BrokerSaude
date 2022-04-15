﻿using BrokerService.Domain.helper;
using System.Linq.Expressions;

namespace BrokerService.Domain.Interfaces.Bases;

public interface IRepoBase<TEntity> : IDisposable where TEntity : Entity
{
    Task Adicionar(TEntity entity);
    Task<TEntity> ObterPorId(Guid id);
    Task<List<TEntity>> ObterTodos();
    Task Atualizar(TEntity entity);
    Task Remover(Guid id);
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}
