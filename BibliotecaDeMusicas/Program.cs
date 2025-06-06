using BibliotecaDeMusicas.Modelos;
using BibliotecaDeMusicas.Implementacoes;


Console.WriteLine("\n===== Biblioteca de Músicas =====");

var repoMusica = new GenericJsonRepository<Musica>();

var musica1 = new Musica
{
    Id = Guid.NewGuid(),
    Titulo = "Bohemian Rhapsody",
    Artista = "Queen",
    Album = "A Night at the Opera",
    Duracao = new TimeSpan(0, 5, 55)
};
repoMusica.Adicionar(musica1);
Console.WriteLine("Música adicionada.");

Console.WriteLine("Músicas cadastradas:");
foreach (var m in repoMusica.ObterTodos())
{
    Console.WriteLine($"{m.Titulo} - {m.Artista} [{m.Duracao}]");
}

var mBusca = repoMusica.ObterPorId(musica1.Id);
if (mBusca != null)
    Console.WriteLine($"\nMúsica encontrada por ID: {mBusca.Titulo}");

repoMusica.Remover(musica1.Id);
Console.WriteLine("Música removida.");