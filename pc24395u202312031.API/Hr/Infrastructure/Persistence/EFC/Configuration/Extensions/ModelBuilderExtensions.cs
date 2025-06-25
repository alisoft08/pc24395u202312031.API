using Microsoft.EntityFrameworkCore;
using pc24395u202312031.API.Hr.Domain.Model.Aggregates;

namespace pc24395u202312031.API.Hr.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyReservationConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Reservation>().HasKey(p => p.Id);
        builder.Entity<Reservation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reservation>().Property(p => p.CustomerName).IsRequired().HasMaxLength(40);
        
        
        


    }
}