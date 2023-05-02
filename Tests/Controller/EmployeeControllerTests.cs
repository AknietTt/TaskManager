using AutoMapper;

using DAL.Interface;
using DAL.Repository;

using Domain.DTO;
using Domain.Models;

using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Service.Implements;
using Service.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManager.Controllers;

using Xunit;

namespace Tests.Controller {
    public class EmployeeControllerTests {
        [Fact]
        public void Should_Return_Employees_ReturnOK() {
            //Arrange
            var service = A.Fake<IEmployeeService>();
            var controller = new EmployeeController(service);

            //Act
            var result = controller.GetAll();

            //Assert
            Assert.NotNull(result);
            
        }

        [Fact]
        public async void Should_Create_Employee_ReturnOK() {
            // Arrange
            var employeeService = A.Fake<IEmployeeService>();
            var controller = new EmployeeController(employeeService);

            var employee = new EmployeeDto {Id = 0, FirstName = "Иван",LastName = "Иванов", ManagerID = 1, Position = "Программист" };

            // Act
            var result = await controller.Add(employee);

            // Assert
           
            Assert.IsType<OkResult>(result);
            //Assert.IsType<BadRequestResult>(result);
           
        }
    }
}
