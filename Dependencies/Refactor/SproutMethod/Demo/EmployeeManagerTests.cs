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

            var mgr = new EmployeeManager();
            var uniqueEmployees = mgr.GetUniqueEmployees(employees);

            uniqueEmployees.Should().BeEmpty();
        }

        [Fact]
        public void When_We_Have_A_List_Of_One_Employee_Then_Return_That_The_List_Of_One_Employee()
        {
            var employees = new List<Employee>()
            {
                new Employee { Number = 17 },
            };

            var mgr = new EmployeeManager();
            var uniqueEmployees = mgr.GetUniqueEmployees(employees);

            uniqueEmployees.Count.Should().Be(1);
            uniqueEmployees[0].Number.Should().Be(17);
        }

        [Fact]
        public void When_We_Have_A_List_Of_Two_Unique_Employees_Then_Return_That_The_List_Of_Two_Employees()
        {
            var employees = new List<Employee>()
            {
                new Employee { Number = 17 },
                new Employee { Number = 23 }
            };

            var mgr = new EmployeeManager();
            var uniqueEmployees = mgr.GetUniqueEmployees(employees);

            uniqueEmployees.Count.Should().Be(2);
            uniqueEmployees[0].Number.Should().Be(17);
            uniqueEmployees[1].Number.Should().Be(23);
        }

        [Fact]
        public void When_We_Have_Two_Duplicate_Employees_Then_Return_Only_One_Unique_Employee()
        {
            var employees = new List<Employee>()
            {
                new Employee { Number = 17 },
                new Employee { Number = 17 }
            };

            var mgr = new EmployeeManager();
            var uniqueEmployees = mgr.GetUniqueEmployees(employees);

            uniqueEmployees.Count.Should().Be(1);
            uniqueEmployees[0].Number.Should().Be(17);
        }

        [Fact]
        public void When_We_Have_Many_Duplicate_Employees_Then_Return_Only_One_Unique_Employees()
        {
            var employees = new List<Employee>()
            {
                new Employee { Number = 17 },
                new Employee { Number = 23 },
                new Employee { Number = 17 },
                new Employee { Number = 1 },
                new Employee { Number = 97 },
                new Employee { Number = 97 },
            };

            var mgr = new EmployeeManager();
            var uniqueEmployees = mgr.GetUniqueEmployees(employees);

            uniqueEmployees.Count.Should().Be(4);
            uniqueEmployees[0].Number.Should().Be(17);
            uniqueEmployees[1].Number.Should().Be(23);
            uniqueEmployees[2].Number.Should().Be(1);
            uniqueEmployees[3].Number.Should().Be(97);
        }
    }
}
