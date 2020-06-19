using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Interfaces
{
    public interface IFeedbackService
    {
        Task<Feedback> PostFeedbackAsync(FeedbackEntity feedback);

        Task<List<Feedback>> GetFeedbackByIdAsync(int memberId);
    }
}
