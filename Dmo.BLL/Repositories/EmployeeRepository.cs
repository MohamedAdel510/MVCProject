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
        private readonly MVCDbContext _dbContext;
        public EmployeeRepository(MVCDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetByAddress(string Address)
            => _dbContext.Employees.Where(E => E.Addres == Address);

    }
}
