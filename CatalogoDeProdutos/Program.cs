using CatalogoDeProdutos.Implementacoes;
using CatalogoDeProdutos.Modelos;

var repositorio = new ProdutoJsonRepository();

Console.WriteLine("====== Catálogo de Produtos ======");

Produto produto1 = new Produto
{
    Id = Guid.NewGuid(),
    Nome = "Notebook Acer Nitro V15",
    Descricao = " Memória 15GB RAM e SSD 500GB",
    Preco = 5600.00m,
    Estoque = 10
};
repositorio.Adicionar(produto1);
Console.WriteLine($"Produto {produto1.Nome} adicionado.");

Produto produto2 = new Produto
{
    Id = Guid.NewGuid(),
    Nome = "Controle PS5 DualSense",
    Descricao = "Controle sem fio",
    Preco = 299.99m,
    Estoque = 5
};

repositorio.Adicionar(produto2);
Console.WriteLine($"Produto {produto2.Nome} adicionado.");

Console.WriteLine("\nProdutos cadastrados:");
foreach (var p in repositorio.ObterTodos())
{
    Console.WriteLine($"{p.Id} | {p.Nome} - R$ {p.Preco} | Estoque: {p.Estoque}");
}

var buscado = repositorio.ObterPorId(produto1.Id);
if (buscado != null)
{
    Console.WriteLine($"\nProduto encontrado por ID: {buscado.Nome}");
}

buscado!.Preco = 5600.00m;
repositorio.Atualizar(buscado);
Console.WriteLine("Produto atualizado.");

if (repositorio.Remover(produto1.Id))
{
    Console.WriteLine("Produto removido.");
}
    