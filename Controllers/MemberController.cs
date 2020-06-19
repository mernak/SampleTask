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
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet(Name = nameof(GetMembers))]
        public async Task<IActionResult> GetMembers()
        {
            var member = await _memberService.GetMembersAsync();
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> Delete(int id)
        {
            var entity = await _memberService.DeleteMembersAsync(id);
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
        public async Task<ActionResult<Member>> Put([FromRoute] int id, [FromBody] MemberEntity member)
        {
            var entity = await _memberService.PutMembersAsync(id, member);
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
        public async Task<ActionResult<Member>> GetById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);

            if (member == null)
                return NotFound();

            return Ok(member);
        }
    }
}
