using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Services;
using TerraEyes_BusinessServer.Services.DataTranslator;

namespace TerraEyes_BusinessServer.Network
{
    [ApiController]
    [Route("[controller]")]
    public class TerrariumController : ControllerBase
    {
        private readonly IMeasurementDataTranslator _measurementDataTranslator;

        public TerrariumController()
        {
            _measurementDataTranslator = new MeasurementDataTranslator();
        }

        
        [HttpPost]
        public ActionResult MeasurementTransmission([FromBody] MeasurementRawInput input)
        {
            //Todo Model validation??

            if (input is null) return BadRequest();

            try
            {
                _measurementDataTranslator.TranslateRawData(input);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(400, e.Message);
            }
        }
    }
}