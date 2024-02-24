using System;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab
{
    public class EmployeePersistanceService
    {
        private SqlEmployeeWriter m_sqlEmployeeWriter;

        public EmployeePersistanceService(AuditLevel audit = AuditLevel.None)
        {
            if (audit == AuditLevel.None)
                throw new Exception("No auditing");

            m_sqlEmployeeWriter = new SqlEmployeeWriter();
        }

        public void SaveEmployee(EmployeeModel e)
        {
            // Before saving recalculate holidays.
            if (e.Salary > 100000 && e.OvertimeAllowanceExceeded)
            {
                e.HolidayDays += 2;
                e.Bonus = 1500;     // TODO: Reduce the bonus to $1250
            }
            else if (e.Salary < 58500 || e.OvertimeAllowanceExceeded)
            {
                e.HolidayDays++;
                e.Bonus = 250;      
            }
            
            m_sqlEmployeeWriter.Save(e);
        }
    }


    public enum AuditLevel
    {
        Low,
        High,
        Medium,
        None
    }
}
