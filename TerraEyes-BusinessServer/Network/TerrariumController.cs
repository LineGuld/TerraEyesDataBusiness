using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TerraEyes_BusinessServer.Models;
using TerraEyes_BusinessServer.Services.DataTranslator;
using TerraEyes_BusinessServer.Services.FeedService;

namespace TerraEyes_BusinessServer.Network
{
    [ApiController]
    [Route("[controller]")]
    public class TerrariumController : ControllerBase
    {
        private readonly IMeasurementDataTranslator _measurementDataTranslator;
        private readonly FeedService _feedService;

        public TerrariumController()
        {
            _measurementDataTranslator = new MeasurementDataTranslator();
            _feedService = FeedService.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetFeedRequests()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> MeasurementTransmission([FromBody] MeasurementRawInput input)
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