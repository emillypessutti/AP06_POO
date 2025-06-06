using System;
using CatalogoDeFilmes.Interfaces;
using CatalogoDeFilmes.Modelos;

namespace CatalogoDeFilmes.Interface;

public interface IFilmeRepository: IRepository<Filme>
{
    IEnumerable<Filme> ObterPorGenero(string genero);
}