using CatalogoDeFilmes.Modelos;
using CatalogoDeFilmes.Implementacoes;

Console.WriteLine("===== Catálogo de Filmes =====");

var filmeRepo = new FilmeJsonRepository();

Filme filme1 = new Filme
{
    Id = Guid.NewGuid(),
    Titulo = "A Origem",
    Diretor = "Christopher Nolan",
    AnoLancamento = 2010,
    Genero = "Ficção"
};

filmeRepo.Adicionar(filme1);
Console.WriteLine("Filme adicionado.");

Console.WriteLine("\nTodos os filmes:");
foreach (var f in filmeRepo.ObterTodos())
{
    Console.WriteLine($"{f.Titulo} ({f.AnoLancamento}) - {f.Genero}");
}

Console.WriteLine("\nFilmes de Ficção:");
var ficcao = filmeRepo.ObterPorGenero("ficção");
foreach (var f in ficcao)
{
    Console.WriteLine($"- {f.Titulo}");
}
