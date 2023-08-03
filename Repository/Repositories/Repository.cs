﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly AppDbContext _context;
        private DbSet<T> entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            T entity = await entities.FirstOrDefaultAsync(m => m.Id == id);
            if (entity is null) throw new NullReferenceException();

            return entity;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.FindAsync(predicate);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task SoftDeleteAsync(T entity)
        {
            T entityDb = await entities.FirstOrDefaultAsync(m => m.Id == entity.Id);
            if (entity is null) throw new NullReferenceException();

            entityDb.SoftDelete = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
