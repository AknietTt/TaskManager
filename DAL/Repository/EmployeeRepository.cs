using AutoMapper;
using DAL.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository {
    public class EmployeeRepository:IEmployeeRepository, IBaseRepository<Employee> {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context,IMapper mapper) {
            _context = context;
        }

        public async Task<bool> Create(Employee entity) {
            await _context.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Employee employee) {
            var employeeToDelete = await _context.Employees.FindAsync(employee.Id);

            if(employeeToDelete == null) {
                return false;
            }
            _context.Employees.Remove(employeeToDelete);

            return await Save();
        }

        public async Task<IEnumerable<Employee>> GetAll() {
            return await _context.Employees.Include(e=>e.Manager).ToListAsync();
        }

        public async Task<Employee> GetById(int id) {
            var employee = await _context.Employees.FindAsync(id);

            if(employee == null) {
                return null;
            }
            return employee;
        }

        public async Task<bool> Update(Employee entity) {
            var employee = await _context.Employees.FindAsync(entity.Id);

            if(employee == null) {
                return false;
            }

            _context.Update(entity);
            return await Save();
        }
        public async Task<bool> Save() {
            var saved =await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAllTasks() {
            var tasks = _context.Tasks.ToList();
            return tasks;
        }
    }
}
