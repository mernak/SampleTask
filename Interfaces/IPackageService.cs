using SampleTaskServerSide.Entities;
using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Interfaces
{
    public interface IPackageService
    {
        Task<List<Package>> GetPackagesAsync();

        Task<Package> PostPackagesAsync(PackageEntity package);

        Task<Package> DeletePackagesAsync(int id);

        Task<Package> PutPackagesAsync(int id, PackageEntity package);

        Task<Package> GetPackageByIdAsync(int id);

    }
}
