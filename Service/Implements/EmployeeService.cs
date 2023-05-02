using AutoMapper;

using DAL.Interface;
using DAL.Repository;
using Domain.DTO;
using Domain.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements {
    public class EmployeeService:IEmployeeService {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper mapper;
        private readonly IManagerRepository _managerRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,IMapper mapper,IManagerRepository manager) {
            _employeeRepository = employeeRepository;
            this.mapper = mapper;
            _managerRepository = manager;
        }

        public async Task<bool> Create(EmployeeDto entity) {
            try {
                if(!ValidationDto(entity)) {
                    return false;
                }
                
                var employee = mapper.Map<Employee>(entity);
                employee.Manager = await _managerRepository.GetById(entity.ManagerID);

                await _employeeRepository.Create(employee);
            } catch(Exception) {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(EmployeeDto entity) {
            try {
                if(!ValidationDto(entity)) {
                    return false;
                }

                var employee = mapper.Map<Employee>(entity);
                await _employeeRepository.Delete(employee);
            } catch(Exception) {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll() {
            var employees = await _employeeRepository.GetAll();
            var employeeDtos = mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeeDtos;
        }

        public async Task<EmployeeDto> GetById(int id) {
            
            var employee = await _employeeRepository.GetById(id);
            
            if(employee == null)
                return null;

            var employeeDto = mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<bool> Update(EmployeeDto employeeDto) {
            var employee = await _employeeRepository.GetById(employeeDto.Id);
            if(employee == null) {
                return false;
            }

            if(!ValidationDto(employeeDto)) {
                return false;
            }
            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.Position = employeeDto.Position;

            await _employeeRepository.Update(employee);
            return true ;
        }

        private bool ValidationDto(EmployeeDto entity) {
            var volidationResults = new List<ValidationResult>();
            if(!Validator.TryValidateObject(entity,new ValidationContext(entity),volidationResults)) {
                return false;
            }
            return true;
        }
    }
}
