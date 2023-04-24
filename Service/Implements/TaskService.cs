using AutoMapper;
using DAL.Interface;
using DAL.Repository;
using Domain.DTO;
using Domain.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Implements {
    public class TaskService:ITaskService {
        private readonly ITaskRepository _taskRepositry;
        private readonly IManagerRepository _managerRepositry;
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepositry,IManagerRepository managerRepositry,IEmployeeRepository employeeRepo,IMapper mapper) {
            _taskRepositry = taskRepositry;
            _managerRepositry = managerRepositry;
            _employeeRepository = employeeRepo;
            _mapper = mapper;
        }

        public async Task<bool> Create(TaskDto entity) {
            try {
                var task = _mapper.Map<Domain.Models.Task>(entity); 
                task.Manager = await _managerRepositry.GetById(entity.ManagerID);
                task.Employee = await _employeeRepository.GetById(entity.EmployeeID);

                await _taskRepositry.Create(task);
            } catch(Exception) {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(TaskDto entity) {
            try {
                var task = _mapper.Map<Domain.Models.Task>(entity);
                await _taskRepositry.Delete(task);
            } catch(Exception) {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<TaskDto>> GetAll() {
            var tasks = await _taskRepositry.GetAll();
            var tasksDtos = _mapper.Map<IEnumerable<Domain.DTO.TaskDto>>(tasks);

            return tasksDtos;
        }

        public async Task<TaskDto> GetById(int id) {
            var task = await _taskRepositry.GetById(id);
            if(task == null)
                return null;

            var taskDto = _mapper.Map<Domain.DTO.TaskDto>(task);
            return taskDto;
        }

        public Task<bool> Update(TaskDto entity) {
            throw new NotImplementedException();
        }
    }
}
