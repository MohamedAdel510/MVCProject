using Demo.DAL.Contextes;
using Demo.DAL.Models;
using Dmo.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmo.BLL.Repositories
{
    public class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MVCDbContext dbContext) : base(dbContext) { }

        //public IQueryable<Employee> GetByAddress(string Address)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
