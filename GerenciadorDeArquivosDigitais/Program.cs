using GerenciadorDeArquivosDigitais.Implementacoes;
using GerenciadorDeArquivosDigitais.Modelos;

Console.WriteLine("\n=== Gerenciador de Arquivos Digitais ===");

var repoArquivos = new ArquivoDigitalJsonRepository();

ArquivoDigital arquivo = new ArquivoDigital
{
    Id = Guid.NewGuid(),
    NomeArquivo = "projeto_final.pdf",
    TipoArquivo = "pdf",
    TamanhoBytes = 204800,
    DataUpload = DateTime.Now
};

repoArquivos.Adicionar(arquivo);
Console.WriteLine("Arquivo adicionado.");

Console.WriteLine("\nArquivos cadastrados:");
foreach (var arq in repoArquivos.ObterTodos())
{
    Console.WriteLine($"{arq.NomeArquivo} ({arq.TipoArquivo}) - {arq.TamanhoBytes} bytes - {arq.DataUpload:d}");
}