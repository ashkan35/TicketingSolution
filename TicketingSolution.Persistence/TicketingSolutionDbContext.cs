using Microsoft.EntityFrameworkCore;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Persistence;

public class TicketingSolutionDbContext:DbContext
{
    public TicketingSolutionDbContext(DbContextOptions<TicketingSolutionDbContext> options):base(options)
    {
        
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Ticket>().HasData(new List<Ticket>
    //    {
    //        new Ticket {Id = 1, Name = "Karaj"},
    //        new Ticket {Id = 1, Name = "Tehran"},
    //        new Ticket {Id = 1, Name = "Shiraz"}
    //    });
    //}
    
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketBooking> TicketBookings { get; set; }
}