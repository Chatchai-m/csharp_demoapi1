using System.Text.Json;
using _2Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
      Log.Logger.Information("List");
      Log.Logger.Error("List error");
      var rs = await _carService.ListCarAsync();
      return Ok(rs);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPost("Add")]
  public async Task<ActionResult> Add([FromBody] CarDTO car_dto)
  {
    try
    {
      if (car_dto == null){
        return BadRequest("Invalid JSON body.");
      }

      if(car_dto.model == null){
        return BadRequest("Model must have value");
      }

      var rs = await _carService.UpsertCarAsync(car_dto);
      return Ok(rs);
    }
    catch (Exception ex)
    {
      return BadRequest("sadasd");
    }
  }

  [HttpPost("Add2")]
  public async Task<ActionResult> Add2()
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
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

}
