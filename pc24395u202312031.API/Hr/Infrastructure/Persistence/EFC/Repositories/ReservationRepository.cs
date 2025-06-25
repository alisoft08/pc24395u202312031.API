using pc24395u202312031.API.Hr.Domain.Model.Aggregates;
using pc24395u202312031.API.Hr.Domain.Repositories;
using pc24395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc24395u202312031.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pc24395u202312031.API.Hr.Infrastructure.Persistence.EFC.Repositories;

public class ReservationRepository(AppDbContext context) : BaseRepository<Reservation>(context), IReservationRepository
{
    public async Task<bool> ExistsByEmailAndCompanyName(string email, string company)
    {
        var exists = Context.Set<Reservation>()
            .Any(r => r.Email == email && r.CompanyName == company);
        return await Task.FromResult(exists);
    }
}