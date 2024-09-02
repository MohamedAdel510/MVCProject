using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmo.BLL.Interfaces
{
    public interface IGenaricRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T Module);
        int Update(T Module);
        int Delete(T Module );
    }
}
