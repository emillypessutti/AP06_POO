using System;
using RegistroDePacientes.Modelos;

namespace RegistroDePacientes.Interfaces;

public interface IPacienteRepository: IRepository<Paciente>
{
    IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima);
}