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
        Task <IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Add(T Module);
        void Update(T Module);
        void Delete(T Module );
    }
}
