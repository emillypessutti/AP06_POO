using System;
using CatalogoDeFilmes.Interface;
using CatalogoDeFilmes.Modelos;

namespace CatalogoDeFilmes.Implementacoes;

public class FilmeJsonRepository : GenericJsonRepository<Filme>, IFilmeRepository
{
    public IEnumerable<Filme> ObterPorGenero(string genero)
    {
        return ObterTodos().Where(f => f.Genero != null && f.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase));
    }
}