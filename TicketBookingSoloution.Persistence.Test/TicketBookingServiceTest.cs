using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TicketingSolution.Domain.Domain;
using TicketingSolution.Persistence;
using TicketingSolution.Persistence.Repositories;
using Xunit;

namespace TicketBookingSoloution.Persistence.Test
{
    public class TicketBookingServiceTest
    {
        [Fact]
        public void Should_Return_Available_Services()
        {
            //Arrange
            var date = new DateTime(2022, 6, 24);
            var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>().UseInMemoryDatabase("AvailableTicketTest",b=>b.EnableNullChecks(false)).Options;
            using var context = new TicketingSolutionDbContext(dbOptions);
            context.Add(new Ticket { Id = 1, Name = "Ticket1",Date=date });
            context.Add(new Ticket { Id = 2, Name = "Ticket2" ,Date=date});
            context.Add(new Ticket { Id = 3, Name = "Ticket3" ,Date=date.AddDays(-1)});
            context.Add(new TicketBooking { Name = "Ashkan", Family = "Semsar", Email = "AshkanSemsar@gmail.com", TicketId = 1, Date = date });
            context.Add(new TicketBooking { Name = "Shayan", Family = "Semsar", Email = "ShayanSemsar@gmail.com", TicketId = 2, Date = date });

            context.SaveChanges();
            var ticketBookingService = new TicketBookingService(context);
            //Act
            var availableServices=ticketBookingService.GetAvailableTickets(date.AddDays(-1)).ToList();
            Assert.Single(availableServices);

        }
    }
}