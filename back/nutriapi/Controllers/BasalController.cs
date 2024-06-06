using Microsoft.AspNetCore.Mvc;
using nutriapi.Models;
using nutriapi.Services;

namespace nutriapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasalController : ControllerBase
    {
        private readonly MetabolismoCalculator _calculator;
        private readonly BasalService _basalService;

        public BasalController(MetabolismoCalculator calculator, BasalService basalService)
        {
            _calculator = calculator;
            _basalService = basalService;
        }

        [HttpPost("metabolismo-basal")]
        public async Task <ActionResult<double>> CalculateBasal(BasalModel basalModel)
        {
            double basalMetabolismo = _calculator.CalculateBasalMetabolism(basalModel);// Faz o cálculo
            basalModel.Date = DateTime.Now;
            basalModel.Basal = Convert.ToInt32(basalMetabolismo);
            await _basalService.AddBasalModelAsync(basalModel); // Armazena no banco
            return Ok(basalMetabolismo); 
        }

        [HttpGet("info")]
        public async Task<ActionResult<IEnumerable<object>>> GetNutritionInfo()
        {
            var basalModels = await _basalService.GetBasalModelsAsync();
            var result = basalModels.Select(info => new { Nome = info.Nome, BasalMetabolismo = _calculator.CalculateBasalMetabolism(info) });
            return Ok(result);
        }
    }
}
