using System.ComponentModel.DataAnnotations;
using pc24395u202312031.API.Hr.Domain.Model.Commands;
using pc24395u202312031.API.Hr.Domain.Model.ValueObjects;

namespace pc24395u202312031.API.Hr.Domain.Model.Aggregates;

public partial class Reservation
{
    public int Id { get; set; }
    
    public string CustomerName { get; set; }
    
    public string CompanyName { get; set; }
    
    public string Email { get; set; }
    
    public string ServiceType { get; private set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public Reservation() {}
    public Reservation(CreateReservationCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.CustomerName) || command.CustomerName.Length < 4)
            throw new ArgumentException("CustomerName debe tener al menos 4 caracteres.");
        CustomerName = command.CustomerName;
        CompanyName = command.CompanyName;
        Email = command.Email;
        
        ServiceType = Enum.Parse<EServiceType>(command.ServiceType).ToString();
        StartDate = command.StartDate;
        EndDate = command.EndDate;
    }
    
}