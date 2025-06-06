using PlataformaCursoOnline.Implementacoes;
using PlataformaCursoOnline.Modelos;
using PlataformaCursoOnline.Servicos;

Console.WriteLine("\n===== Plataforma de Cursos Online =====");

var repoCursos = new CursoOnlineJsonRepository();
var servico = new CatalogoCursosService(repoCursos);

CursoOnline curso = new CursoOnline
{
    Id = Guid.NewGuid(),
    Titulo = "Programação Orientada a Objetos com C#",
    Instrutor = "Everton Coimbra",
    CargaHoraria = 20
};

if (servico.AdicionarCurso(curso))
    Console.WriteLine("Curso adicionado com sucesso!");

servico.AdicionarCurso(curso);

Console.WriteLine("\nCursos disponíveis:");
foreach (var c in servico.ListarCursos())
{
    Console.WriteLine($"{c.Titulo} - {c.Instrutor} ({c.CargaHoraria}h)");
}
