using System;
using RegistroDePacientes.Interfaces;
using RegistroDePacientes.Modelos;

namespace RegistroDePacientes.Implementacoes;

public class PacienteJsonRepository: GenericJsonRepository<Paciente>, IPacienteRepository
{
    public IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima)
    {
        DateTime hoje = DateTime.Today;

        return ObterTodos().Where(p =>
        {
            var idade = hoje.Year - p.DataNascimento.Year;
            if (p.DataNascimento > hoje.AddYears(-idade))
                idade--;

            return idade >= idadeMinima && idade <= idadeMaxima;
        });
    }
}