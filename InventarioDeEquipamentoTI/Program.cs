using InventarioDeEquipamentoTI.Modelos;
using InventarioDeEquipamentoTI.Implementacoes;

Console.WriteLine("\n===== Inventário de Equipamentos de TI (Em Memória) =====");

var repoEquipamentos = new InMemoryEquipamentoTIRepository();

EquipamentoTI equipamento1 = new EquipamentoTI
{
    Id = Guid.NewGuid(),
    NomeEquipamento = "Notebook Dell XPS",
    TipoEquipamento = "Notebook",
    NumeroSerie = "ABC123456789",
    DataAquisicao = new DateTime(2022, 3, 15)
};

repoEquipamentos.Adicionar(equipamento1);
Console.WriteLine("Equipamento adicionado.");

Console.WriteLine("\nLista de Equipamentos:");
foreach (var eq in repoEquipamentos.ObterTodos())
{
    Console.WriteLine($"{eq.NomeEquipamento} ({eq.TipoEquipamento}) - Nº de Série: {eq.NumeroSerie}");
}
