using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface {
    public interface IBaseRepository <T>{
        Task<bool> Create(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);
        Task<bool> Save();
    }
}
