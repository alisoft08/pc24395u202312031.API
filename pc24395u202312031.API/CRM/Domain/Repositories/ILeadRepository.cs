using pc24395u202312031.API.CRM.Domain.Model.Aggregates;
using pc24395u202312031.API.Shared.Domain.Repositories;

namespace pc24395u202312031.API.CRM.Domain.Repositories;

public interface ILeadRepository : IBaseRepository<Lead>
{
    Task<bool> ExistsByFirstNameAndLastName(string firstName, string lastName);
}