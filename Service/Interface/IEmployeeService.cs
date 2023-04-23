using Domain.DTO;
using Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface {
    public interface IEmployeeService {
        Task<bool> Create(EmployeeDto entity);
        Task<EmployeeDto> GetById(int id);
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<bool> Delete(EmployeeDto entity);
        Task<bool> Update(EmployeeDto entity);
    }
}
