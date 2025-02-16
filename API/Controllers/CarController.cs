using System.Text.Json;
using _2Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
// [ServiceFilter(typeof(AuthFilter))]
public class CarController: ControllerBase
{
  private ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

  [HttpGet("List")]
  public async Task<ActionResult> List()
  {
    try
    {
      var rs = await _carService.ListCarAsync();
      return Ok(rs);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPost("Add")]
  public async Task<ActionResult> Add()
  {
    try
    {
      using (StreamReader reader = new StreamReader(Request.Body))
      {
        string rawData = await reader.ReadToEndAsync();
        var dataObject = JsonSerializer.Deserialize<CarDTO>(rawData);
        var rs = await _carService.UpsertCarAsync(dataObject);
        return Ok(rs);
      }
      // return Ok("Hello world");
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
