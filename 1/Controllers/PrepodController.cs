﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _1.Filters.PrepodKafedraFilters;
using _1.Interfaces;
using _1.Database;
using _1.Models;

namespace _1.Controllers
{    
    [ApiController]
    [Route("prepod")]
    public class PrepodController : ControllerBase
    {
        private readonly ILogger<PrepodController> _logger;
        private readonly IPrepodService _prepodService;
        private PrepodDbcontext _context;


        public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService, PrepodDbcontext context)
        {
            _logger = logger;
            _prepodService = prepodService;
            _context = context;
        }

        [HttpPost(Name = "GetPrepodsByKafedra")]
        public async Task<IActionResult> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodsByKafedraAsync(filter, cancellationToken);

            return Ok(prepod);
        }
        [HttpPost("AddPrepod", Name = "AddPrepod")]
        public IActionResult CreatePrepod([FromBody] Prepod prepod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Prepod.Add(prepod);
            _context.SaveChanges();
            return Ok(prepod);
        }
        [HttpPut("EditPrepod")]
        public IActionResult UpdatePrepod(string firstname, [FromBody] Prepod updatedPrepod)
        {
            var existingPrepod = _context.Prepod.FirstOrDefault(g => g.FirstName == firstname);

            if (existingPrepod == null)
            {
                return NotFound();
            }

            existingPrepod.FirstName = updatedPrepod.FirstName;
            existingPrepod.LastName = updatedPrepod.LastName;
            existingPrepod.MiddleName = updatedPrepod.MiddleName;
            existingPrepod.KafedraId = updatedPrepod.KafedraId;
            existingPrepod.StepenId = updatedPrepod.StepenId;
            _context.SaveChanges();

            return Ok();
        }
        //добавление для кафедры
        [HttpPost("AddKafedra", Name = "AddKafedra")]
        public IActionResult CreateKafedra([FromBody] _1.Models.Kafedra kafedra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kafedra.Add(kafedra);
            _context.SaveChanges();
            return Ok(kafedra);
        }

        [HttpPut("EditKafedra")]
        public IActionResult UpdateKafedra(string kafedraname, [FromBody] Kafedra updatedKafedra)
        {
            var existingKafedra = _context.Kafedra.FirstOrDefault(g => g.KafedraName == kafedraname);

            if (existingKafedra == null)
            {
                return NotFound();
            }

            existingKafedra.KafedraName = updatedKafedra.KafedraName;
            _context.SaveChanges();

            return Ok();
        }
        //удаление для кафедры
        [HttpDelete("DeleteKafedra")]
        public IActionResult DeleteKafedra(string kafedraName, _1.Models.Kafedra updatedKafedra)
        {
            var existingKafedra = _context.Kafedra.FirstOrDefault(g => g.KafedraName == kafedraName);

            if (existingKafedra == null)
            {
                return NotFound();
            }
            _context.Kafedra.Remove(existingKafedra);
            _context.SaveChanges();

            return Ok();
        }

    }
}
