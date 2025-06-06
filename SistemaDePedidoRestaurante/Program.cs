using SistemaDePedidoRestaurante.Implementacoes;
using SistemaDePedidoRestaurante.Modelos;

Console.WriteLine("\n===== Cardápio =====");

var repoCardapio = new GenericJsonRepository<ItemCardapio>();

var prato = new Prato
{
    Id = Guid.NewGuid(),
    NomeItem = "Lasanha Quatro Queijos",
    Preco = 32.90m,
    DescricaoDetalhada = "Lasanha com molho branco e quatro queijos",
    Vegetariano = true
};
repoCardapio.Adicionar(prato);

var bebida = new Bebida
{
    Id = Guid.NewGuid(),
    NomeItem = "Suco de Uva Natural",
    Preco = 7.50m,
    VolumeMl = 300,
    Alcoolica = false
};
repoCardapio.Adicionar(bebida);

Console.WriteLine("\nItens do Cardápio:");
foreach (var item in repoCardapio.ObterTodos())
{
    Console.WriteLine($"→ {item.NomeItem} - R$ {item.Preco}");
}