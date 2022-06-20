namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Salary { get; set; }
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
