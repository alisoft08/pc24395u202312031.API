using pc24395u202312031.API.Hr.Domain.Model.Aggregates;
using pc24395u202312031.API.Hr.Domain.Model.Commands;
using pc24395u202312031.API.Hr.Domain.Model.ValueObjects;
using pc24395u202312031.API.Hr.Domain.Repositories;
using pc24395u202312031.API.Hr.Domain.Services;
using pc24395u202312031.API.Shared.Domain.Repositories;

namespace pc24395u202312031.API.Hr.Application.Internal.CommandServices;

public class ReservationCommandService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
: IReservationCommandService 
{
    public async Task<Reservation?> CreateReservationAsync(CreateReservationCommand command)
    {
        if (await reservationRepository.ExistsByEmailAndCompanyName(command.Email, command.CompanyName))
        {
            throw new Exception("Reservation with the same email and company name already exists");
        }

        // Validate service type as enum
        if (!Enum.IsDefined(typeof(EServiceType), command.ServiceType))
        {
            throw new Exception("Invalid service type");
        }

        var reservation = new Reservation(command);
        await reservationRepository.AddAsync(reservation);
        await unitOfWork.CompleteAsync();
        return reservation;
    }
    
}