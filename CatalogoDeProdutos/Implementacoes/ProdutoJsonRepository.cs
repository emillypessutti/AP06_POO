using System;
using System.Text.Json;
using CatalogoDeProdutos.Interfaces;
using CatalogoDeProdutos.Modelos;

namespace CatalogoDeProdutos.Implementacoes;

public class ProdutoJsonRepository : IProdutoRepository
{
    private readonly string _caminhoArquivo = "produtos.json";
    private List<Produto> _produtos = new();

    public ProdutoJsonRepository()
    {
        if (File.Exists(_caminhoArquivo))
        {
            var json = File.ReadAllText(_caminhoArquivo);
            var lista = JsonSerializer.Deserialize<List<Produto>>(json);
            if (lista != null)
                _produtos = lista;
        }
    }

    private void Salvar()
    {
        var json = JsonSerializer.Serialize(_produtos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_caminhoArquivo, json);
    }

    public void Adicionar(Produto produto)
    {
        _produtos.Add(produto);
        Salvar();
    }

    public Produto? ObterPorId(Guid id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public List<Produto> ObterTodos()
    {
        return _produtos;
    }

    public void Atualizar(Produto produto)
    {
        var existente = ObterPorId(produto.Id);
        if (existente != null)
        {
            existente.Nome = produto.Nome;
            existente.Descricao = produto.Descricao;
            existente.Preco = produto.Preco;
            existente.Estoque = produto.Estoque;
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var produto = ObterPorId(id);
        if (produto != null)
        {
            _produtos.Remove(produto);
            Salvar();
            return true;
        }
        return false;
    }
}
