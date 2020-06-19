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
    public class TrainerService : ITrainerService
    {
        private readonly SampleWebProjectDbContext _context;
        private readonly IMapper _mapper;
        public TrainerService(SampleWebProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Trainer>> GetTrainersAsync()
        {
            var trainer = await _context.Trainers.ToListAsync();
            if (trainer == null)
            {
                return null;
            }
            return _mapper.Map<List<Trainer>>(trainer);
        }

        public async Task<Trainer> PostTrainersAsync(TrainerEntity trainer)
        {
            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();
            return _mapper.Map<Trainer>(trainer);
        }

        public async Task<Trainer> DeleteTrainersAsync(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return null;
            }
            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();
            return _mapper.Map<Trainer>(trainer);
        }
        
        public async Task<Trainer> PutTrainersAsync(int id, TrainerEntity trainer)
        {
            if (id != trainer.Id)
            {
                return null;
            }
            try
            {
                _context.Entry(trainer).State = EntityState.Modified;
                var user = await _context.Users.Where(x => x.Username == trainer.Username).FirstOrDefaultAsync();
                user.Password = trainer.Password;

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
            
            return _mapper.Map<Trainer>(trainer);
        }


        public async Task<Trainer> GetTrainerByIdAsync(int id)
        {
            var trainer = await _context.Trainers.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (trainer == null)
            {
                return null;
            }
            return _mapper.Map<Trainer>(trainer);
        }
    }
}
