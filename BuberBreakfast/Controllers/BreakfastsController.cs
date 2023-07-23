using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
namespace BuberBreakfast.Controllers;


[ApiController]
[Route("[controller]")]
public class BreakfastController : ControllerBase
{
    [HttpPost()]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        return Ok();
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok();
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        return Ok();
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok();
    }
}