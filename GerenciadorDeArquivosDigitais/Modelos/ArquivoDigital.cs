using System;
using GerenciadorDeArquivosDigitais.Entidades;

namespace GerenciadorDeArquivosDigitais.Modelos;

public class ArquivoDigital: IEntidade
{
    public Guid Id { get; set; }
    public string NomeArquivo { get; set; } = "";
    public string TipoArquivo { get; set; } = ""; // Ex: "pdf", "jpg", "docx"
    public long TamanhoBytes { get; set; }
    public DateTime DataUpload { get; set; }
}