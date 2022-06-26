namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo_Magic
{
    public class Employee
    {
        public string Name { get; set; }
        public EmployeeStatus Status { get; set; }
        public string EmployeeNumber { get; set; }
        public EmploymentType Type { get; set; }

        // Salary Details
        public int AnnualSalary { get; set; }
        public string PaymentFrequency { get; set; }
        public int AnnualHolidaysAllowance { get; set; }
        public decimal AccumulatedHolidays { get; set; }
        public int AnnualSickDayAllowance { get; set; }
        public int AnnualSickDayTaken { get; set; }
    }
}
