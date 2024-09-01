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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MVCDbContext dbContext;
        public DepartmentRepository(MVCDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public int Add(Department department)
        {
            dbContext.Add(department);
            return dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            dbContext.Remove(department);
            return dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll() =>
            dbContext.Departments.ToList();
        

        public Department GetById(int id)
        {
            return dbContext.Departments.Find(id);
        }

        public int Update(Department department)
        {
            dbContext.Update(department);
            return dbContext.SaveChanges();
        }
    }
}
