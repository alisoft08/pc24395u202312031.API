
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using pc24395u202312031.API.Hr.Infrastructure.Persistence.EFC.Configuration.Extensions;
using pc24395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace pc24395u202312031.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyReservationConfiguration();
        builder.UseSnakeCaseNamingConvention();
        
        // Publishing Context
       
    }
}