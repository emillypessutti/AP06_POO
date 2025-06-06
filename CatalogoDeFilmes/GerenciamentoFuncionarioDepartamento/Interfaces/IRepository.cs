using System;
using GerenciamentoFuncionarioDepartamento.Entidades;

namespace GerenciamentoFuncionarioDepartamento.Interfaces;

public interface IRepository<T> where T : IEntidade
{
    void Adicionar(T entidade);
    T? ObterPorId(Guid id);
    List<T> ObterTodos();
    void Atualizar(T entidade);
    bool Remover(Guid id);
}