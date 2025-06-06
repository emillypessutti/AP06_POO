using GerenciamentoFuncionarioDepartamento.Implementacoes;
using GerenciamentoFuncionarioDepartamento.Modelos;

Console.WriteLine("\n===== Funcionários e Departamentos =====");

var repoDepartamentos = new GenericJsonRepository<Departamento>();
var repoFuncionarios = new GenericJsonRepository<Funcionario>();

var depTI = new Departamento
{
    Id = Guid.NewGuid(),
    NomeDepartamento = "Tecnologia da Informação",
    Sigla = "TI"
};
repoDepartamentos.Adicionar(depTI);

var func1 = new Funcionario
{
    Id = Guid.NewGuid(),
    NomeCompleto = "Emilly Pessutti",
    Cargo = "Customer Support Engineer",
    DepartamentoId = depTI.Id
};
repoFuncionarios.Adicionar(func1);

Console.WriteLine("\nFuncionários:");
var departamentos = repoDepartamentos.ObterTodos();
foreach (var f in repoFuncionarios.ObterTodos())
{
    var dep = departamentos.FirstOrDefault(d => d.Id == f.DepartamentoId);
    var nomeDep = dep != null ? dep.NomeDepartamento : "Departamento não encontrado";

    Console.WriteLine($"{f.NomeCompleto} - {f.Cargo} | Departamento: {nomeDep}");
}