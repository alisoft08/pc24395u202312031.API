namespace pc24395u202312031.API.Hr.Domain.Model.Commands;

public record CreateReservationCommand(string CustomerName, string CompanyName, string Email, string ServiceType,
    DateTime StartDate, DateTime EndDate);