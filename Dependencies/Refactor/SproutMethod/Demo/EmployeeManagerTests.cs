using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace Dependencies.Refactor.SproutMethod.Demo
{
    public class EmployeeManagerTests
    {
        [Fact]
        public void When_Have_Empty_List_Of_Employees_Then_Return_Empty_List()
        {
            var employees = new List<Employee>();
            
            var uniqueEmployees = new EmployeeManager().FilterUniqueEmployees(employees);
            
            uniqueEmployees.Should().BeEmpty();
        }

        [Fact]
        public void When_We_Have_A_List_Of_One_Employee_Then_Return_That_The_List_Of_One_Employee()
        {
            var employees = new List<Employee> { new() { Number = 17 } };
            
            var uniqueEmployees = new EmployeeManager().FilterUniqueEmployees(employees);
            
            uniqueEmployees.Count.Should().Be(1);
            uniqueEmployees[0].Number.Should().Be(17);
        }

        [Fact]
        public void When_We_Have_A_List_Of_Two_Unique_Employees_Then_Return_That_The_List_Of_Two_Employees()
        {
            // TODO: Write test
        }

        [Fact]
        public void When_We_Have_Two_Duplicate_Employees_Then_Return_Only_One_Unique_Employee()
        {
            // TODO: Write test
        }


        // More tests??
    }
}
