using System;
using PlataformaCursoOnline.Modelos;

namespace PlataformaCursoOnline.Interfaces;

public interface ICursoOnlineRepository: IRepository<CursoOnline>
{
    CursoOnline? ObterPorTitulo(string titulo);
}