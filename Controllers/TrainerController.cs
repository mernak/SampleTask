using Microsoft.AspNetCore.Mvc;
using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Interfaces;
using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private ITrainerService _trainerService;
        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        [HttpGet(Name = nameof(GetTrainers))]
        public async Task<IActionResult> GetTrainers()
        {
            var trainer = await _trainerService.GetTrainersAsync();
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Trainer>> Delete(int id)
        {
            var entity = await _trainerService.DeleteTrainersAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(entity);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Trainer>> Put([FromRoute] int id, [FromBody] TrainerEntity trainer)
        {
            var entity = await _trainerService.PutTrainersAsync(id, trainer);
            if (entity == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(entity);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetById(int id)
        {
            var trainer = await _trainerService.GetTrainerByIdAsync(id);

            if (trainer == null)
                return NotFound();

            return Ok(trainer);
        }
    }
}
