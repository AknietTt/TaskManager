using AutoMapper;
using DAL.Interface;
using Domain.DTO;
using FakeItEasy;
using Service.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Service {
    public class ManagerServiceTests {
        public static IEnumerable<object[]> ManagerTestData =>
        new List<object[]>
        {
            new object[] { new ManagerDto { Id = 0, FirstName = "Иван", LastName = "Иванов",  Position = "Программист" }, true },
            new object[] { new ManagerDto { Id = 0, FirstName = "Иван", LastName = "Иванов",  Position = "Программист" }, true  },

            new object[] { new ManagerDto { Id = 0, FirstName = "", LastName = "Иванов",  Position = "Программист" }, false },
            new object[] { new ManagerDto { Id = 0, FirstName = "Иван", LastName = "",  Position = "Программист" }, false },
            new object[] { new ManagerDto { Id = 0, FirstName = "Иван", LastName = "",  Position = "" }, false },

            new object[] { new ManagerDto { Id = 0, FirstName = null, LastName = "Иванов",  Position = "" }, false },
            new object[] { new ManagerDto { Id = 0, FirstName = "Ивано", LastName = null,  Position = "" }, false },
            new object[] { new ManagerDto { Id = 0, FirstName = "Ивано", LastName = "Иванов",  Position = null }, false },

        };

        [Theory, MemberData(nameof(ManagerTestData))]
        public async void Add_Should_Create_Manager_ReturnTrue(ManagerDto manager,bool expected) {
            //Arrange
            var repositoryManager = A.Fake<IManagerRepository>();
            var mapper = A.Fake<IMapper>();
            var service = new ManagerService(repositoryManager,mapper);

            //Act
            var res = await service.Create(manager);

            //Assert

            Assert.Equal(expected,res);
        }

        [Theory, MemberData(nameof(ManagerTestData))]
        public async void Delete_Should_Delete_Manager_ReturnTrue(ManagerDto manager, bool expected) {
            //Arrange
            var repositoryManager = A.Fake<IManagerRepository>();
            var mapper = A.Fake<IMapper>();
            var service = new ManagerService(repositoryManager,mapper);

            //Act
            var res = await service.Delete(manager);

            //Assert
            Assert.Equal(expected,res);
        }

        [Theory, MemberData(nameof(ManagerTestData))]
        public async void Update_Should_Update_Manager_ReturnTrue(ManagerDto manager,bool expected) {
            //Arrange
            var repositoryManager = A.Fake<IManagerRepository>();
            var mapper = A.Fake<IMapper>();
            var service = new ManagerService(repositoryManager,mapper);

            //Act
            var res = await service.Update(manager);

            //Assert
            Assert.Equal(expected,res);

        }
    }
}
