namespace pc24395u202312031.API.Hr.Interfaces.REST.Resources;

public record CreateReservationResource(string CustomerName, string CompanyName, string Email, string ServiceType,
    DateTime StartDate, DateTime EndDate);