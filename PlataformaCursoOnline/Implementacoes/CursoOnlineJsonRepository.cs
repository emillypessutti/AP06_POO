using System;
using PlataformaCursoOnline.Interfaces;
using PlataformaCursoOnline.Modelos;

namespace PlataformaCursoOnline.Implementacoes;

public class CursoOnlineJsonRepository : GenericJsonRepository<CursoOnline>, ICursoOnlineRepository
{
    public CursoOnline? ObterPorTitulo(string titulo)
    {
        return ObterTodos().FirstOrDefault(c =>
            c.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }
}