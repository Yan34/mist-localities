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
        [Route("")]
        public async Task<IActionResult> GetLocalities()
        {
            return Ok(await _db.GetLocalities());
        }

        [HttpGet]
        [Route(("{id}"))]
        public async Task<IActionResult> GetLocality(int id)
        {
            return Ok(await _db.GetLocality(id));
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLocality(Locality loc)
        {
            var result = await _db.AddLocality(loc);
            if(result.id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to insert locality to DB");
            }
            return Ok("New locality added");
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateLocality(Locality loc)
        {
            await _db.UpdateLocality(loc);
            return Ok("Locality is updated");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult DeleteLocality(int id)
        {
            _db.DeleteLocality(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
