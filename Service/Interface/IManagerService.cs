using Domain.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface {
    public interface IManagerService {
        Task<bool> Create(ManagerDto entity);
        Task<ManagerDto> GetById(int id);
        Task<IEnumerable<ManagerDto>> GetAll();
        Task<bool> Delete(ManagerDto entity);
        Task<bool> Update(ManagerDto entity);
    }
}
