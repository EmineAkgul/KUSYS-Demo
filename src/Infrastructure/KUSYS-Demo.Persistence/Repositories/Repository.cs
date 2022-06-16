using KUSYS_Demo.Application.IRepositories;
using KUSYS_Demo.Domain.Entity;
using KUSYS_Demo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            var save = await context.SaveChangesAsync();
            if (save > 0)
                return entity;
            else
                return null;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id);
            if (entity == null)
            {
                return null;
            }

            //context.Set<T>().Remove(entity);

            entity.UpdatedDate = DateTime.Now;
            entity.IsDeleted = true;
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().Where(i => !i.IsDeleted).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(i=>!i.IsDeleted && i.Id==Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            entity.UpdatedDate = DateTime.Now;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
