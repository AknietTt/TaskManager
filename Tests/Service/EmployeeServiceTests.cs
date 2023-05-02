using AutoMapper;
using DAL.Interface;
using Domain.DTO;
using Domain.Models;

using FakeItEasy;
using Moq;
using Service.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Tests.Service {
    public class EmployeeServiceTests {
        public static IEnumerable<object[]> EmployeeTestData =>
        new List<object[]>
        {
            new object[] { new EmployeeDto { Id = 0, FirstName = "Иван", LastName = "Иванов", ManagerID = 1, Position = "Программист" }, true },
            new object[] { new EmployeeDto { Id = 0, FirstName = "Иван", LastName = "Иванов", ManagerID = 0, Position = "Программист" }, true  },

            new object[] { new EmployeeDto { Id = 0, FirstName = "", LastName = "Иванов", ManagerID = 0, Position = "Программист" }, false },
            new object[] { new EmployeeDto { Id = 0, FirstName = "Иван", LastName = "", ManagerID = 0, Position = "Программист" }, false },
            new object[] { new EmployeeDto { Id = 0, FirstName = "Иван", LastName = "", ManagerID = 0, Position = "" }, false },

            new object[] { new EmployeeDto { Id = 0, FirstName = null, LastName = "Иванов", ManagerID = 0, Position = "" }, false },
            new object[] { new EmployeeDto { Id = 0, FirstName = "Ивано", LastName = null, ManagerID = 0, Position = "" }, false },
            new object[] { new EmployeeDto { Id = 0, FirstName = "Ивано", LastName = "Иванов", ManagerID = 0, Position = null }, false },

        };

        [Theory, MemberData(nameof(EmployeeTestData))]
        public async void Add_Should_Create_Employee_ReturnTrue(EmployeeDto employee,bool expected) {
            //Arrange
            var repository = A.Fake<IEmployeeRepository>();
            var repositoryManager = A.Fake<IManagerRepository>();
            var mapper = A.Fake<IMapper>();
            var service = new EmployeeService(repository,mapper,repositoryManager);

            //Act
             var res = await service.Create(employee);
            
            //Assert

            Assert.Equal(expected , res);
        }

        [Theory, MemberData(nameof(EmployeeTestData))]
        public async void Delete_Should_Delete_Employee_ReturnTrue(EmployeeDto employee,bool expected) {
            //Arrange
            var repository = A.Fake<IEmployeeRepository>();
            var repositoryManager = A.Fake<IManagerRepository>();
            var mapper = A.Fake<IMapper>();
            var service = new EmployeeService(repository,mapper,repositoryManager);

            //Act
            var res = await service.Create(employee);
            
            //Assert
            Assert.Equal(expected,res);
        }

        [Theory, MemberData(nameof(EmployeeTestData))]
        public async void Update_Should_Update_Employee_ReturnTrue(EmployeeDto employee,bool expected) {
            //Arrange
            var repository = A.Fake<IEmployeeRepository>();
            var repositoryManager = A.Fake<IManagerRepository>();
            var mapper = A.Fake<IMapper>();
            var service = new EmployeeService(repository,mapper,repositoryManager);

            //Act
            var res = await service.Update(employee);

            //Assert
            Assert.Equal(expected,res);
        }



    }
}
