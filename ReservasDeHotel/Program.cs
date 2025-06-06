using ReservasDeHotel.Implementacoes;
using ReservasDeHotel.Modelos;

Console.WriteLine("\n=== Reservas de Hotel ===");

var repoReservas = new ReservaHotelJsonRepository();

var reserva = new ReservaHotel
{
    Id = Guid.NewGuid(),
    NomeCliente = "Emilly Pessutti",
    DataEntrada = new DateTime(2025, 7, 10),
    DataSaida = new DateTime(2025, 7, 15),
    Status = StatusReserva.Confirmada
};

repoReservas.Adicionar(reserva);
Console.WriteLine("Reserva adicionada.");

Console.WriteLine("\nReservas Confirmadas:");
var confirmadas = repoReservas.ObterPorStatus(StatusReserva.Confirmada);
foreach (var r in confirmadas)
{
    Console.WriteLine($"{r.NomeCliente} - {r.DataEntrada:dd/MM/yyyy} até {r.DataSaida:dd/MM/yyyy}");
}