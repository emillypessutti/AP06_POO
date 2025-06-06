using RegistroDePacientes.Modelos;
using RegistroDePacientes.Implementacoes;

Console.WriteLine("\n=== Registro de Pacientes ===");

var pacienteRepo = new PacienteJsonRepository();

Paciente paciente1 = new Paciente
{
    Id = Guid.NewGuid(),
    NomeCompleto = "Mariana Pessutti",
    DataNascimento = new DateTime(2001, 7, 12),
    ContatoEmergencia = "Mãe: 99999-1234"
};

pacienteRepo.Adicionar(paciente1);
Console.WriteLine("Paciente adicionado.");

Console.WriteLine("\nPacientes com idade entre 15 e 30 anos:");
var pacientesFiltrados = pacienteRepo.ObterPorFaixaEtaria(15, 30);
foreach (var p in pacientesFiltrados)
{
    var idade = DateTime.Today.Year - p.DataNascimento.Year;
    if (p.DataNascimento > DateTime.Today.AddYears(-idade))
        idade--;

    Console.WriteLine($"{p.NomeCompleto} - {idade} anos");
}