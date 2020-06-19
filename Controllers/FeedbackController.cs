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
    public class FeedbackController : ControllerBase
    {
        private IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbacks(int id)
        {
            var feedbacks = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedbacks == null)
            {
                return NotFound();
            }
            return Ok(feedbacks);
        }
        [HttpPost]
        public async Task<ActionResult<Feedback>> Post([FromBody]FeedbackEntity feedback)
        {
            var entity = await _feedbackService.PostFeedbackAsync(feedback);
            return CreatedAtAction(
                "GetFeedbacks",
                new { id = feedback.Id },
                entity
                );

        }
    }
}
