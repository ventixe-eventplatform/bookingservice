using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    [HttpPost("create")]
    public async Task<IActionResult> CreateBookingAsync(CreateBookingModel model)
    {
        var result = await _bookingService.CreateBookingAsync(model);
        return result.Success ? Ok(result) : StatusCode(500, new { error = result.Error });
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetBookingsAsync(string customerId)
    {
        var result = await _bookingService.GetBookingsAsync(customerId);
        return result != null ? Ok(result) : NotFound();
    }

    //[HttpGet("{bookingId}")]
    //public async Task<IActionResult> GetBookingAsync(string bookingId)
    //{

    //}
}
