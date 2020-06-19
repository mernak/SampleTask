using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Interfaces;
using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Services
{
    public class PackageService : IPackageService
    {
        private readonly SampleWebProjectDbContext _context;
        private readonly IMapper _mapper;
        public PackageService(SampleWebProjectDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Package>> GetPackagesAsync()
        {
            var package = await _context.Packages.ToListAsync();
            if (package == null)
            {
                return null;
            }
            return _mapper.Map<List<Package>>(package);
           // throw new NotImplementedException();
        }

        public async Task<Package> PostPackagesAsync(PackageEntity package)
        {
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return _mapper.Map<Package>(package);
        }

        public async Task<Package> DeletePackagesAsync(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if(package == null)
            {
                return null; 
            }
            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return _mapper.Map<Package>(package); 
        }

        public async Task<Package> PutPackagesAsync(int id, PackageEntity package)
        {
            if(id != package.Id)
            {
                return null;
            }
            _context.Entry(package).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<Package>(package);
        }


        public async Task<Package> GetPackageByIdAsync(int id)
        {
            var package = await _context.Packages.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (package == null)
            {
                return null;
            }
            return _mapper.Map<Package>(package);
        }
    }
}
