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
    public class ManagerService:IManagerService {
        private readonly IManagerRepository _managerRepositry;
        private readonly IMapper _mapper;
        public ManagerService(IManagerRepository managerRepositry, IMapper mapper) {
            _mapper = mapper;
            _managerRepositry = managerRepositry;
        }

        public async Task<bool> Create(ManagerDto entity) {
            try {
                if(!ValidationDto(entity)){
                    return false;
                }
                var manager = _mapper.Map<Manager>(entity);
                await _managerRepositry.Create(manager);
            } catch(Exception) {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(ManagerDto entity) {
            try {
                if(!ValidationDto(entity)) {
                    return false;
                }
                var manager = _mapper.Map<Manager>(entity);
                await _managerRepositry.Delete(manager);
            } catch(Exception) {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<ManagerDto>> GetAll() {
            var managers = await _managerRepositry.GetAll();
            var mangersDtos = _mapper.Map<IEnumerable<ManagerDto>>(managers);
            return mangersDtos;
        }

        public async Task<ManagerDto> GetById(int id) {
            var manager = await _managerRepositry.GetById(id);
            if(manager == null)
                return null;

            var managerDto = _mapper.Map<ManagerDto>(manager);
            return managerDto;
        }

        public async Task<bool> Update(ManagerDto entity) {
            if(!ValidationDto(entity)) {
                return false;
            }
            var manager = await _managerRepositry.GetById(entity.Id);
            if(manager == null) {
                return false;
            }

            manager.FirstName = entity.FirstName;
            manager.LastName = entity.LastName;
            manager.Position = entity.Position;

            await _managerRepositry.Update(manager);
            return true;
        }


        private bool ValidationDto(ManagerDto entity) {
            var volidationResults = new List<ValidationResult>();
            if(!Validator.TryValidateObject(entity,new ValidationContext(entity),volidationResults)) {
                return false;
            }
            return true;
        }
    }
}
