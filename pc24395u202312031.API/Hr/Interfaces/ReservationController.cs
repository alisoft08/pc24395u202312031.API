using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using pc24395u202312031.API.Hr.Domain.Services;
using pc24395u202312031.API.Hr.Interfaces.REST.Resources;
using pc24395u202312031.API.Hr.Interfaces.REST.Transform;

namespace pratica_pc2_1.API.Hr.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ReservationController(IReservationCommandService reservationCommandService): ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateReservation(CreateReservationResource resource)
    {
        var createReservationCommand = CreateReservationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var reservation = await reservationCommandService.CreateReservationAsync(createReservationCommand);
        var reservationResource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
        return StatusCode(201, reservationResource);
    }
}