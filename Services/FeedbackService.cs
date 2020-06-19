using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Interfaces;
using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly SampleWebProjectDbContext _context;
        private readonly IMapper _mapper;
        public FeedbackService(SampleWebProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Feedback>> GetFeedbackByIdAsync(int memberId)
        {
           var feedback = await _context.Feedbacks.Where(x => x.MemberId == memberId).ToListAsync();
            if(feedback == null)
            {
                return null;
            }
            return _mapper.Map<List<Feedback>>(feedback);
        }

        public async Task<Feedback> PostFeedbackAsync(FeedbackEntity feedback)
        {
            feedback.Date = DateTime.Today;
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return _mapper.Map<Feedback>(feedback);
        }
    }
}
