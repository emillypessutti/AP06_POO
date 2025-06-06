using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using SistemaDePedidoRestaurante.Entidades;
using SistemaDePedidoRestaurante.Interfaces;

namespace SistemaDePedidoRestaurante.Implementacoes;

public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
{
    private readonly string _arquivo;
    private List<T> _dados = new();

    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        IncludeFields = true,
        Converters = { new JsonStringEnumConverter() },
        TypeInfoResolver = new DefaultJsonTypeInfoResolver().WithAddedModifier(typeInfo =>
        {
            if (typeInfo.Type == typeof(SistemaDePedidoRestaurante.Modelos.ItemCardapio))
            {
                typeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                {
                    TypeDiscriminatorPropertyName = "$type",
                    IgnoreUnrecognizedTypeDiscriminators = true,
                    DerivedTypes =
                    {
                        new JsonDerivedType(typeof(SistemaDePedidoRestaurante.Modelos.Prato), "Prato"),
                        new JsonDerivedType(typeof(SistemaDePedidoRestaurante.Modelos.Bebida), "Bebida")
                    }
                };
            }
        })
    };

    public GenericJsonRepository()
    {
        var nomeArquivo = typeof(T).Name.ToLower() + "s.json";
        _arquivo = nomeArquivo;

        if (File.Exists(_arquivo))
        {
            var json = File.ReadAllText(_arquivo);
            var lista = JsonSerializer.Deserialize<List<T>>(json, _options);
            if (lista != null)
                _dados = lista;
        }
    }

    protected void Salvar()
    {
        var json = JsonSerializer.Serialize(_dados, _options);
        File.WriteAllText(_arquivo, json);
    }

    public void Adicionar(T entidade)
    {
        _dados.Add(entidade);
        Salvar();
    }

    public T? ObterPorId(Guid id)
    {
        return _dados.FirstOrDefault(e => e.Id == id);
    }

    public List<T> ObterTodos()
    {
        return _dados;
    }

    public void Atualizar(T entidade)
    {
        var existente = ObterPorId(entidade.Id);
        if (existente != null)
        {
            _dados.Remove(existente);
            _dados.Add(entidade);
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = ObterPorId(id);
        if (entidade != null)
        {
            _dados.Remove(entidade);
            Salvar();
            return true;
        }
        return false;
    }
}
