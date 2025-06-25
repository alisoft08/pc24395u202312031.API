using pc24395u202312031.API.Hr.Domain.Model.Commands;
using pc24395u202312031.API.Hr.Interfaces.REST.Resources;

namespace pc24395u202312031.API.Hr.Interfaces.REST.Transform;

public class CreateReservationCommandFromResourceAssembler 
{
    
    public static CreateReservationCommand ToCommandFromResource (
        CreateReservationResource resource) =>
        new CreateReservationCommand(
            resource.CustomerName,
            resource.CompanyName,
            resource.Email,
            resource.ServiceType,
            resource.StartDate,
            resource.EndDate
            );
    
}