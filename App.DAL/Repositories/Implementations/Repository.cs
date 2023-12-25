using App.CORE.Entities.Common;
using App.DAL.Context;
using App.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task Create(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void delete(int id)
        {
            var brand=Table.FirstOrDefault(b=>b.Id==id);
            if (brand != null)
            {
            brand.IsDeleted = true;           
            }
        }

        public void deleteAll()
        {
            foreach (var item in Table)
            {
                item.IsDeleted = true;
            }
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = Table.Where(b=>!b.IsDeleted);
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public async Task<T> GetById(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IQueryable<T>> RecycleBin(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = Table.Where(b => b.IsDeleted);
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public void restore()
        {
            foreach (var item in Table)
            {
                item.IsDeleted = false;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Update(entity);

        }
    }
}
