using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace Dependencies.Refactor.SproutMethod.Demo
{
    public class EmployeeManagerTests
    {
        [Fact]
        public void Given_Have_No_Employees__When_GetUniqueEmployees__Then_Return_Empty_List()
        {
            var noEmployees = BuildEmployeesWithNumbers();
            var uniqueEmployees = new EmployeeManager().GetUniqueEmployees(noEmployees);
            uniqueEmployees.Should().BeEmpty();
        }

        [Fact]
        public void Given_Have_One_Employee__When_GetUniqueEmployees__Then_Return_List_Of_One_Employee()
        {
            var employees = BuildEmployeesWithNumbers(17);
            var uniqueEmployees = new EmployeeManager().GetUniqueEmployees(employees);
            VerifyUniqueEmployeesWithNumbers(uniqueEmployees, 17);
        }

        [Fact]
        public void Given_Have_Two_Unique_Employees__When_GetUniqueEmployees__Then_Return_List_Of_Two_Employees()
        {
            var employees = BuildEmployeesWithNumbers(17, 23);
            var uniqueEmployees = new EmployeeManager().GetUniqueEmployees(employees);
            VerifyUniqueEmployeesWithNumbers(uniqueEmployees, 17, 23);
        }

        [Fact]
        public void Given_Have_Two_Duplicate_Employees__When_GetUniqueEmployees__Then_Return_Only_One_Unique_Employee()
        {
            var employees = BuildEmployeesWithNumbers(17, 17);
            var uniqueEmployees = new EmployeeManager().GetUniqueEmployees(employees);
            VerifyUniqueEmployeesWithNumbers(uniqueEmployees, 17);
        }

        [Fact]
        public void When_We_Have_Many_Duplicate_Employees_Then_Return_Only_Unique_Employees()
        {
            var employees = BuildEmployeesWithNumbers(17, 23, 17, 1, 94, 94);
            var uniqueEmployees = new EmployeeManager().GetUniqueEmployees(employees);
            VerifyUniqueEmployeesWithNumbers(uniqueEmployees, 1, 17, 23, 94);
        }



        private static IEnumerable<Employee> BuildEmployeesWithNumbers(params int[] numbers)
        {
            return numbers.Select(number => new Employee { Number = number }).ToList();
        }

        private static void VerifyUniqueEmployeesWithNumbers(IList<Employee> uniqueEmployees, params int[] uniqueNumbers)
        {
            uniqueEmployees.Count.Should().Be(uniqueNumbers.Length);
            
            uniqueNumbers.Intersect(uniqueEmployees.Select(x => x.Number))
                .Should().BeEquivalentTo(uniqueNumbers);
        }
    }
}
