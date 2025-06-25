using pc24395u202312031.API.Hr.Domain.Model.Aggregates;
using pc24395u202312031.API.Hr.Domain.Model.Commands;
using pc24395u202312031.API.Shared.Domain.Repositories;

namespace pc24395u202312031.API.Hr.Domain.Repositories;

/// <summary>
/// Reservation repository interface
/// </summary>

public interface IReservationRepository : IBaseRepository<Reservation>
{
    
    /// <summary>
    /// Find if it is a unique reservation
    /// </summary>
    
    Task<bool> ExistsByEmailAndCompanyName(string email, string company);
    
}