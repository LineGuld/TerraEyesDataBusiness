using System;
using System.Collections.Generic;
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
        private readonly FeedService _feedService;

        public TerrariumController()
        {
            _measurementDataTranslator = new MeasurementDataTranslator();
            _feedService = FeedService.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetFeedRequests()
        {
            if (!_feedService.HasNewRequests()) return Ok(null);
            
            List<string> preppedRequests = new List<string>();
            preppedRequests.AddRange(_feedService.GetUnsentRequests());
            _feedService.UpdateSentRequests();
            return Ok(preppedRequests);

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