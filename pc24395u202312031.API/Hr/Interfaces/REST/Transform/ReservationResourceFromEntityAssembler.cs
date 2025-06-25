using pc24395u202312031.API.Hr.Domain.Model.Aggregates;
using pc24395u202312031.API.Hr.Interfaces.REST.Resources;

namespace pc24395u202312031.API.Hr.Interfaces.REST.Transform;

public class ReservationResourceFromEntityAssembler
{
    public static ReservationResource ToResourceFromEntity(Reservation entity) => new ReservationResource(
        entity.Id,
        entity.Email,
        entity.CustomerName,
        entity.CompanyName,
        entity.ServiceType,
        entity.StartDate,
        entity.EndDate);
}