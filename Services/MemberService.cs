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
    public class MemberService : IMemberService
    {
        private readonly SampleWebProjectDbContext _context;
        private readonly IMapper _mapper;
        public MemberService(SampleWebProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Member>> GetMembersAsync()
        {
            var member = await _context.Members.ToListAsync();
            if (member == null)
            {
                return null;
            }
            return _mapper.Map<List<Member>>(member);
        }

        public async Task<Member> PostMembersAsync(MemberEntity member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return _mapper.Map<Member>(member);
        }

        public async Task<Member> DeleteMembersAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return null;
            }
            _context.Members.Remove(member);
            var user = await _context.Users.Where(x => x.Username == member.Username).FirstOrDefaultAsync();
            _context.Users.Remove(user); 
            await _context.SaveChangesAsync();
            return _mapper.Map<Member>(member);
        }

        public async Task<Member> PutMembersAsync(int id, MemberEntity member)
        {
            if (id != member.Id)
            {
                return null;
            }
            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<Member>(member);
        }


        public async Task<Member> GetMemberByIdAsync(int id)
        {
            var member = await _context.Members.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (member == null)
            {
                return null;
            }
            return _mapper.Map<Member>(member);
        }
    }
}
