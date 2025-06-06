using System;
using SistemaDePedidoRestaurante.Entidades;

namespace SistemaDePedidoRestaurante.Modelos;

public class ItemCardapio: IEntidade
{
    public Guid Id { get; set; }
    public string? NomeItem { get; set; }
    public decimal Preco { get; set; }
}