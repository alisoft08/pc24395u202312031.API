using pc24395u202312031.API.Hr.Domain.Model.Aggregates;
using pc24395u202312031.API.Hr.Domain.Model.Commands;

namespace pc24395u202312031.API.Hr.Domain.Services;

public interface IReservationCommandService
{
    Task<Reservation?> CreateReservationAsync(CreateReservationCommand command);
}