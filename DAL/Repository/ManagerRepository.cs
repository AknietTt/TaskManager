using DAL.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository {
    public class ManagerRepository:IManagerRepository, IBaseRepository<Manager> {
        private readonly ApplicationDbContext _context;

        public ManagerRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Create(Manager entity) {
            await _context.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Manager entity) {
            var managerToDelete = await _context.Managers.FindAsync(entity.Id);

            if(managerToDelete == null) {
                return false;
            }
            _context.Managers.Remove(managerToDelete);

            return await Save();
        }

        public async Task<IEnumerable<Manager>> GetAll() {
            return await _context.Managers.ToListAsync();
        }

        public async Task<Manager> GetById(int id) {
            Manager manager =  _context.Managers.FirstOrDefault(x=>x.Id == id); 
            if(manager == null) {
                return null;
            }
            return manager;
        }

        public async Task<bool> Save() {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> Update(Manager entity) {
            var manager = await _context.Managers.FindAsync(entity.Id);

            if(manager == null) {
                return false;
            }
            _context.Update(entity);
            return await Save();
        }
    }
}
