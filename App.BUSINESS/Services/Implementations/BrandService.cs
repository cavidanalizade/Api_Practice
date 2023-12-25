using App.BUSINESS.DTOs.Brand;
using App.BUSINESS.Services.Interfaces;
using App.CORE.Entities;
using App.DAL.Repositories.Implementations;
using App.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repo;

        public BrandService(IBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task Create(CreateBrandDto createBrandDto)
        {
            Brand brand = new Brand()
            {
                Name = createBrandDto.Name
            };
            await _repo.Create(brand);
            _repo.Save();
        }

        public async Task Delete(int id)
        {
            _repo.delete(id);
            _repo.Save();
        }

        public async Task DeleteAll()
        {
            _repo.deleteAll();
            _repo.Save();
        }

        public async Task<ICollection<Brand>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
             return await categories.ToListAsync(); 
        }

        public async Task<Brand> GetById(int id)
        {
            if(id<=0) throw new Exception("Bad Request");
            return await _repo.GetById(id);
        }

        public async Task<ICollection<Brand>> RecycleBin()
        {
            var categories = await _repo.RecycleBin();
            _repo.Save();
            return await categories.ToListAsync();
        }

        public async Task Restore()
        {
             _repo.restore();
             _repo.Save();
        }

        public async Task Update(UpdateBrandDto updateBrandDto)
        {

            if (updateBrandDto == null) throw new Exception("Bad Request");

            var existingBrand = await _repo.GetById(updateBrandDto.Id);
            existingBrand.Name = updateBrandDto.Name;
            _repo.Update(existingBrand);
            _repo.Save();
        }
    }
}
