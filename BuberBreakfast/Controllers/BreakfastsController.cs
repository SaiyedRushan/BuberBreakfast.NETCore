using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;


[ApiController]
[Route("breakfasts")]
public class BreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            id: Guid.NewGuid(),
            name: request.Name,
            description: request.Description,
            startDateTime: request.StartDateTime,
            endDateTime: request.EndDateTime,
            lastModifiedDateTime: DateTime.UtcNow,
            savory: request.Savory,
            sweet: request.Sweet
        );

        // TODO: save breakfast to database
        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            Id: breakfast.Id,
            Name: breakfast.Name,
            Description: breakfast.Description,
            StartDateTime: breakfast.StartDateTime,
            EndDateTime: breakfast.EndDateTime,
            LastModifiedDateTime: breakfast.LastModifiedDateTime,
            Savory: breakfast.Savory,
            Sweet: breakfast.Sweet
        );

        return CreatedAtAction(nameof(GetBreakfast), new { id = response.Id }, response);
    }

    [Route("{id:guid}")]
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            id: id,
            name: request.Name,
            description: request.Description,
            startDateTime: request.StartDateTime,
            endDateTime: request.EndDateTime,
            lastModifiedDateTime: DateTime.UtcNow,
            savory: request.Savory,
            sweet: request.Sweet
        );
        _breakfastService.UpsertBreakfast(breakfast);

        return NoContent();
    }

    [Route("")]
    [HttpGet()]
    public IActionResult GetBreakfasts()
    {
        List<Breakfast> breakfasts = _breakfastService.GetBreakfasts();
        return Ok(breakfasts);
    }

    [Route("{id:guid}")]
    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastService.GetBreakfast(id);
        var response = new BreakfastResponse(
            Id: breakfast.Id,
            Name: breakfast.Name,
            Description: breakfast.Description,
            StartDateTime: breakfast.StartDateTime,
            EndDateTime: breakfast.EndDateTime,
            LastModifiedDateTime: breakfast.LastModifiedDateTime,
            Savory: breakfast.Savory,
            Sweet: breakfast.Sweet
        );
        return Ok(response);
    }

    [Route("{id:guid}")]
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);
        return NoContent();
    }
}