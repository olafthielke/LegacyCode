namespace Dependencies.Refactor.SproutMethod.Demo
{
    public class Employee
    {
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public EmployeeStatus Status { get; set; }
        public int LocationId { get; set; }
        public Address Address { get; set; }
    }
}
