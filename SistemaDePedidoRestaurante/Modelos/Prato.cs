using System;

namespace SistemaDePedidoRestaurante.Modelos;

public class Prato: ItemCardapio
{
    public string? DescricaoDetalhada { get; set; }
    public bool Vegetariano { get; set; }
}