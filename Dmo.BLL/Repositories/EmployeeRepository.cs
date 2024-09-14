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
        private readonly MVCDbContext _Context;
        public EmployeeRepository(MVCDbContext Context) : base(Context)
        {
            _Context = Context;
        }

        public IQueryable<Employee> GetByAddress(string Address)
        {
            return _Context.Employees.Where(E => E.Addres == Address);
        }

        public IQueryable<Employee> GetByName(string SearchValue)
        {
            return _Context.Employees.Where(E => E.Name.ToLower().Contains(SearchValue.ToLower()));
        }
    }
}
