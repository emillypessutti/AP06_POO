using System;
using GerenciamentoFuncionarioDepartamento.Entidades;

namespace GerenciamentoFuncionarioDepartamento.Modelos;

public class Departamento : IEntidade
{
    public Guid Id { get; set; }
    public string? NomeDepartamento { get; set; }
    public string? Sigla { get; set; }
}