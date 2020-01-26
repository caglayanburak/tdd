using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repository;

namespace TDDSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanDetailRepository _planDetailRepository;
        public PlanController(IPlanDetailRepository planDetailRepository)
        {
            _planDetailRepository = planDetailRepository;
        }

        // POST api/plan/create-plan-details
        [HttpPost("create-plan-details")]
        public IActionResult CreatePlanDetails([FromBody] int inventoryItemId)
        {
            var isExists = _planDetailRepository.IsExists(inventoryItemId);

            if(isExists)
            {
                return BadRequest("Bu detay daha önce eklenmiştir");
            }

            var result = _planDetailRepository.BulkSaveAsync(new List<PlanDetail>());

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
