using System;
using ReservasDeHotel.Interfaces;
using ReservasDeHotel.Modelos;

namespace ReservasDeHotel.Implementacoes;

public class ReservaHotelJsonRepository: GenericJsonRepository<ReservaHotel>, IReservaHotelRepository
{
    public IEnumerable<ReservaHotel> ObterPorStatus(StatusReserva status)
    {
        return ObterTodos().Where(r => r.Status == status);
    }
}