using Demo.DAL.Contextes;
using Dmo.BLL.Interfaces;
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

        public int Add(T Module)
        {
            _dbContext.Add(Module);
            return _dbContext.SaveChanges();
        }

        public int Delete(T Module)
        {
            _dbContext.Remove(Module);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll() => 
            _dbContext.Set<T>().ToList();

        public T GetById(int id) =>
            _dbContext.Set<T>().Find(id);

        public int Update(T Module)
        {
            _dbContext.Update(Module);
            return _dbContext.SaveChanges();
        }
    }
}
