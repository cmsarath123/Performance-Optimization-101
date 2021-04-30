using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FxRatesController : ControllerBase
    {
        [Route("{baseCurrency}/{targetCurrency}")]
        public async Task<IActionResult> Get([FromRoute]string baseCurrency, [FromRoute]string targetCurrency)
        {
            return Ok(await Task.FromResult(new {
                BaseCurrency = "usd",
                TargetCurrency = "inr",
                Rate = 80.0d
            }));
        }
    }
}
