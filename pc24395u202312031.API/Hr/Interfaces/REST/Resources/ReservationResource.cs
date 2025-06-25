namespace pc24395u202312031.API.Hr.Interfaces.REST.Resources;

public record ReservationResource(int Id, string CustomerName, string CompanyName, string email, string ServiceType,
    DateTime StartDate, DateTime EndDate);