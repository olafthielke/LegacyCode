using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo_Magic
{
    public class DbSalaryDetails
    {
        public int AnnualSalary { get; set; }
        public string PaymentFrequency { get; set; }
        public int AnnualHolidaysAllowance { get; set; }
        public decimal AccumulatedHolidays { get; set; }
        public int AnnualSickDayAllowance { get; set; }
        public int AnnualSickDayTaken { get; set; }
    }
}
