using System;
using RegistroDePacientes.Entidades;
using RegistroDePacientes.Implementacoes;

namespace RegistroDePacientes.Interfaces;

public interface IRepository<T> where T : IEntidade
{
    void Adicionar(T entidade);
    T? ObterPorId(Guid id);
    List<T> ObterTodos();
    void Atualizar(T entidade);
    bool Remover(Guid id);
}