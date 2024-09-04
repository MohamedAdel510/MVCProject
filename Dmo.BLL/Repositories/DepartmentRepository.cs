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
    public class DepartmentRepository : GenaricRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MVCDbContext dbContext):base(dbContext) 
        {
            
        }
    }
}
