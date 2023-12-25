using App.BUSINESS.DTOs.Brand;
using App.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.Services.Interfaces
{
    public interface IBrandService
    {
        Task<ICollection<Brand>> GetAllAsync();
        Task<ICollection<Brand>> RecycleBin();
        Task<Brand> GetById(int id);
        Task Create(CreateBrandDto createBrandDto);
        Task Delete(int id);
        Task DeleteAll();
        Task Update(UpdateBrandDto updateBrandDto);
        Task Restore();

    }
}
