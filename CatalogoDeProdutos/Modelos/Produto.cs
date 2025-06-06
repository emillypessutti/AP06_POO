using System;
using CatalogoDeProdutos.Entidades;

namespace CatalogoDeProdutos.Modelos;

public class Produto : IEntidade
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}
