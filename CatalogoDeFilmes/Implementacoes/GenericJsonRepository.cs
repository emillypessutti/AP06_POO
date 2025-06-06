using System;
using System.Text.Json;
using CatalogoDeFilmes.Entidade;
using CatalogoDeFilmes.Interfaces;

namespace CatalogoDeFilmes.Implementacoes;

public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
{
    private readonly string _arquivo;
    private List<T> _dados = new();

    public GenericJsonRepository()
    {
        var nomeArquivo = typeof(T).Name.ToLower() + "s.json";
        _arquivo = nomeArquivo;

        if (File.Exists(_arquivo))
        {
            var json = File.ReadAllText(_arquivo);
            var lista = JsonSerializer.Deserialize<List<T>>(json);
            if (lista != null)
                _dados = lista;
        }
    }

    protected void Salvar()
    {
        var json = JsonSerializer.Serialize(_dados, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_arquivo, json);
    }

    public void Adicionar(T entidade)
    {
        _dados.Add(entidade);
        Salvar();
    }

    public T? ObterPorId(Guid id)
    {
        return _dados.FirstOrDefault(e => e.Id == id);
    }

    public List<T> ObterTodos()
    {
        return _dados;
    }

    public void Atualizar(T entidade)
    {
        var existente = ObterPorId(entidade.Id);
        if (existente != null)
        {
            _dados.Remove(existente);
            _dados.Add(entidade);
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = ObterPorId(id);
        if (entidade != null)
        {
            _dados.Remove(entidade);
            Salvar();
            return true;
        }
        return false;
    }
}