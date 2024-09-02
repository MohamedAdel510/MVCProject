using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmo.BLL.Interfaces
{
    public interface IEmployeeRepository:IGenaricRepository<Employee>
    {
        //IQueryable<Employee> GetByAddress(string Address);
    }
}
