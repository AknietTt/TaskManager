using Domain.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface {
    public interface ITaskService {
        Task<bool> Create(TaskDto entity);
        Task<TaskDto> GetById(int id);
        Task<IEnumerable<TaskDto>> GetAll();
        Task<bool> Delete(TaskDto entity);
        Task<bool> Update(TaskDto entity);
    }
}
