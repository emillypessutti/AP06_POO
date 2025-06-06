using System;
using PlataformaCursoOnline.Interfaces;
using PlataformaCursoOnline.Modelos;

namespace PlataformaCursoOnline.Servicos;

public class CatalogoCursosService
{
    private readonly ICursoOnlineRepository _repo;

    public CatalogoCursosService(ICursoOnlineRepository repo)
    {
        _repo = repo;
    }

    public bool AdicionarCurso(CursoOnline curso)
    {
        if (_repo.ObterPorTitulo(curso.Titulo) != null)
        {
            Console.WriteLine($"Curso com o título '{curso.Titulo}' já existe.");
            return false;
        }

        _repo.Adicionar(curso);
        return true;
    }

    public List<CursoOnline> ListarCursos()
    {
        return _repo.ObterTodos();
    }
}