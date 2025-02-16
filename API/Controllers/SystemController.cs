using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
// [ServiceFilter(typeof(AuthFilter))]
public class SystemController: ControllerBase
{
  [HttpGet("GetVersion")]
  public async Task<ActionResult> GetVersion()
  {
    try
    {
      return Ok("version1.0.0");
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPost("GetDatetime")]
  public async Task<ActionResult> GetDatetime()
  {
    try
    {
      return Ok(DateTime.Now.ToString("yyyyMMdd_HHmmss"));
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
