using System;
using GerenciadorDeArquivosDigitais.Interfaces;
using GerenciadorDeArquivosDigitais.Modelos;

namespace GerenciadorDeArquivosDigitais.Implementacoes;

public class ArquivoDigitalJsonRepository: GenericJsonRepository<ArquivoDigital>, IArquivoDigitalRepository
{
    // Nenhuma implementação extra necessária por enquanto.
}
