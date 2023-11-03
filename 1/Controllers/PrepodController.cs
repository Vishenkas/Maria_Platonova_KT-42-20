using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _1.Filters.PrepodFilters;
using _1.Interfaces;

namespace _1.Controllers
{    
    [ApiController]
    [Route("controller")]
    public class PrepodController : ControllerBase
    {
        private readonly ILogger<PrepodController> _logger;
        private readonly IPrepodService _prepodService;

        
        public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService)
        {
            _logger = logger;
            _prepodService = prepodService;
        }

        [HttpPost(Name = "GetPrepodsByGroup")]
        public async Task<IActionResult> GetPrepodsByGroupAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodsByGroupAsync(filter, cancellationToken);

            return Ok(prepod);
        }
    }
}
