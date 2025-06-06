using System;
using System.Text.Json;
using BibliotecaDeMusicas.Entidades;
using BibliotecaDeMusicas.Interfaces;

namespace BibliotecaDeMusicas.Implementacoes;

public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
{
    private readonly string _arquivo;
    private List<T> _entidades = new();

    public GenericJsonRepository()
    {
        var nomeClasse = typeof(T).Name.ToLower();
        _arquivo = $"{nomeClasse}s.json";

        if (File.Exists(_arquivo))
        {
            var json = File.ReadAllText(_arquivo);
            var lista = JsonSerializer.Deserialize<List<T>>(json);
            if (lista != null)
                _entidades = lista;
        }
    }

    private void Salvar()
    {
        var json = JsonSerializer.Serialize(_entidades, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_arquivo, json);
    }

    public void Adicionar(T entidade)
    {
        _entidades.Add(entidade);
        Salvar();
    }

    public T? ObterPorId(Guid id)
    {
        return _entidades.FirstOrDefault(e => e.Id == id);
    }

    public List<T> ObterTodos()
    {
        return _entidades;
    }

    public void Atualizar(T entidade)
    {
        var existente = ObterPorId(entidade.Id);
        if (existente != null)
        {
            _entidades.Remove(existente);
            _entidades.Add(entidade);
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = ObterPorId(id);
        if (entidade != null)
        {
            _entidades.Remove(entidade);
            Salvar();
            return true;
        }
        return false;
    }
}
