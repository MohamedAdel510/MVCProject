using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmo.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        // Signeture for Propety
        IEmployeeRepository EmployeeRepository { get; set; }
        IDepartmentRepository DepartmentRepository { get; set; }
        Task<int> CompleteAsync();
        void Dispose();
    }
}
