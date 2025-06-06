using System;
using ReservasDeHotel.Modelos;

namespace ReservasDeHotel.Interfaces;

public interface IReservaHotelRepository: IRepository<ReservaHotel>
{
    IEnumerable<ReservaHotel> ObterPorStatus(StatusReserva status);
}