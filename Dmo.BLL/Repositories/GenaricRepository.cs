using Demo.DAL.Contextes;
using Demo.DAL.Models;
using Dmo.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmo.BLL.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly MVCDbContext _dbContext;
        public GenaricRepository(MVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Add(T Module)
        {
            await _dbContext.AddAsync(Module);
        }

        public void Delete(T Module)
        {
            _dbContext.Remove(Module);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) await _dbContext.Employees.Include(E => E.Department).ToListAsync();
            }
            return  await _dbContext.Set<T>().ToListAsync();
        }
            

        public async Task<T> GetByIdAsync(int id)
            => await _dbContext.Set<T>().FindAsync(id);
        
         
        public void Update(T Module)
        {
            _dbContext.Update(Module);
        }
    }
}
