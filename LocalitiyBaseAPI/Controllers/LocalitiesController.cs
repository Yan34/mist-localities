using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalityBaseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalityBaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalitiesController : ControllerBase
    {
        private LocalitiesContext _db;

        private readonly ILogger<LocalitiesController> _logger;

        public LocalitiesController(LocalitiesContext context, ILogger<LocalitiesController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetLocalities")]
        public async Task<IActionResult> GetLocalities()
        {
            return Ok(await _db.GetLocalities());
        }

        [HttpGet]
        [Route(("GetLocality/{id}"))]
        public async Task<IActionResult> GetLocality(int id)
        {
            return Ok(await _db.GetLocality(id));
        }

        [HttpPost]
        [Route("AddLocality")]
        public async Task<IActionResult> Post(Locality loc)
        {
            var result = await _db.InsertLocality(loc);
            if(result.id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to insert locality to DB");
            }
            return Ok("New locality added");
        }

        [HttpPut]
        [Route("UpdateLocality")]
        public async Task<IActionResult> Put(Locality loc)
        {
            await _db.UpdateLocality(loc);
            return Ok("Locality is updated");
        }

        [HttpDelete]
        [Route("DeleteLocality/{id}")]
        public JsonResult Delete(int id)
        {
            _db.DeleteLocality(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
