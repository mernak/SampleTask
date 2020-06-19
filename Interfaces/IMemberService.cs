using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Interfaces
{
    public interface IMemberService
    {
        Task<List<Member>> GetMembersAsync();

        Task<Member> PostMembersAsync(MemberEntity Member);

        Task<Member> DeleteMembersAsync(int id);

        Task<Member> PutMembersAsync(int id, MemberEntity Member);

        Task<Member> GetMemberByIdAsync(int id);
    }
}
