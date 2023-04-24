using DAL.Interface;

using Domain.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository {
    public class TaskRepository:ITaskRepository, IBaseRepository<Domain.Models.Task> {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Create(Domain.Models.Task entity) {
            await _context.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Domain.Models.Task entity) {
            var taskToDelete = await _context.Tasks.FindAsync(entity.Id);
            if(taskToDelete == null) { 
                return false;
            }
            _context.Remove(taskToDelete);
            return await Save();
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAll() {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Domain.Models.Task> GetById(int id) {
            var task = await _context.Tasks.FindAsync(id);
            if(task == null) {
                return null;
            }
            return task;
        }

        public async Task<bool> Save() {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public Task<bool> Update(Domain.Models.Task entity) {
            throw new NotImplementedException();
        }
    }
}
