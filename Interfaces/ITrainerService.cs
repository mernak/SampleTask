using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Interfaces
{
    public interface ITrainerService
    {
        Task<List<Trainer>> GetTrainersAsync();

        Task<Trainer> PostTrainersAsync(TrainerEntity Trainer);

        Task<Trainer> DeleteTrainersAsync(int id);

        Task<Trainer> PutTrainersAsync(int id, TrainerEntity Trainer);

        Task<Trainer> GetTrainerByIdAsync(int id);
    }
}
