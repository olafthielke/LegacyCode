namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Salary { get; set; }
        public int Bonus { get; set; }
        public int HolidayDays { get; set; }
        public bool OvertimeAllowanceExceeded { get; set; }
        public DayOfTheWeek PaymentDate { get; set; }
    }


    public enum DayOfTheWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6
    }
}
