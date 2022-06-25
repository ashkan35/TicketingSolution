using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TicketingSolution.Core.Enum;
using TicketingSolution.Core.Handler;
using TicketingSolution.Core.Model;
using TicketingSolution.WebApi.Controllers;
using Xunit;

namespace TicketingSolution.WebApi.Test;

public class BookingControllerTest
{
    private Mock<ITicketBookingRequestHandler> _ticketBookingHandler;
    private BookingController _controller;
    private TicketBookingRequest _request;
    private TicketBookingResult _result;
    public BookingControllerTest()
    {
        _ticketBookingHandler = new Mock<ITicketBookingRequestHandler>();
        _controller= new BookingController(_ticketBookingHandler.Object);
        _request = new TicketBookingRequest();
        _result = new TicketBookingResult();
        _ticketBookingHandler.Setup(x => x.BookService(_request)).Returns(_result);
    }
    [Theory]
    [InlineData(1, true, typeof(OkObjectResult), BookingResultFlag.Success)]
    [InlineData(0, false, typeof(BadRequestObjectResult), BookingResultFlag.Failure)]
    public async Task Should_Call_Booking_Method_When_Valid(int expectedMethodCalls, bool isModelValid,
        Type expectedActionResultType, BookingResultFlag bookingResultFlag)
    {
        // Arrange
        if (!isModelValid)
        {
            _controller.ModelState.AddModelError("Key", "ErrorMessage");
        }

        _result.Flag = bookingResultFlag;


        // Act
        var result = await _controller.Book(_request);

        // Assert
        result.ShouldBeOfType(expectedActionResultType);
        _ticketBookingHandler.Verify(x => x.BookService(_request), Times.Exactly(expectedMethodCalls));

    }
}