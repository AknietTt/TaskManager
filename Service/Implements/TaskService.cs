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

        public async Task<bool> Create(TaskDto entity, int managerId, int employeeId) {
            try {
                var task = _mapper.Map<Domain.Models.Task>(entity);
                task.Employee = await _employeeRepository.GetById(employeeId);
                task.Manager = await _managerRepositry.GetById(managerId);
                
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
            IEnumerable<Domain.Models.Task> tasks = await _taskRepositry.GetAll();
            IEnumerable<TaskDto> tasksDtos = _mapper.Map<IEnumerable<TaskDto>>(tasks);

            return tasksDtos;
        }

        public async Task<TaskDto> GetById(int id) {
            var task = await _taskRepositry.GetById(id);
            if(task == null)
                return null;

            var taskDto = _mapper.Map<Domain.DTO.TaskDto>(task);
            return taskDto;
        }

        public async Task<ManagerDto> GetManager(int idTask) {
            var task = await _taskRepositry.GetById(idTask);
            var manager = task.Manager;
            var managerDto = _mapper.Map<ManagerDto>(manager);
            return managerDto;
        }

        public Task<bool> Update(TaskDto entity) {
            throw new NotImplementedException();
        }
    }
}
