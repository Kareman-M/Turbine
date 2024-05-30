using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Turbine.Data;

namespace Turbin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {

        FactoryService factoryService;
        public MainController()
        {
            factoryService = ServiceHelper.GetService<FactoryService>();
        }

        [HttpGet("Get")]
        public IActionResult Get(int pageIndex = 0, string sector = null, string citycode = "1")
        {
            try
            {
                var result = factoryService.Filter(out int length, pageIndex, sector, citycode);
                return Ok(new { result, length });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCities")]
        public IActionResult GetCities()
        {
            try
            {

                return Ok(factoryService.GetCities());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSectors/{cityCode}")]
        public IActionResult GetSectors(string cityCode)
        {
            try
            {

                return Ok(factoryService.GetSectors(cityCode));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
