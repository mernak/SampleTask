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
    public class PackageController : ControllerBase
    {
        private IPackageService _packageService;
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }
        [HttpGet(Name = nameof(GetPackages))]
        public async Task<IActionResult> GetPackages()
        {
            var package = await _packageService.GetPackagesAsync();
            if (package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }

        [HttpPost(Name = nameof(Post))]
        public async Task<ActionResult<Package>> Post([FromBody]PackageEntity package)
        {
            var entity = await _packageService.PostPackagesAsync(package);
            return CreatedAtAction(
                "GetPackages",
                new { id = package.Id },
                package
                );

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Package>> Delete(int id)
        {
            var entity = await _packageService.DeletePackagesAsync(id);
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
        public async Task<ActionResult<Package>> Put([FromRoute] int id, [FromBody] PackageEntity package)
        {
            var entity = await _packageService.PutPackagesAsync(id, package);
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
        public async Task<ActionResult<Package>> GetById(int id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);

            if (package == null)
                return NotFound();

            return Ok(package);
        }

    }
}
