using System;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab
{
    public class EmployeePersistanceService
    {
        private ISqlEmployeeWriter m_sqlEmployeeWriter;

        public EmployeePersistanceService(AuditLevel audit = AuditLevel.None)
        {
            if (audit == AuditLevel.None)
                throw new Exception("No auditing");

            m_sqlEmployeeWriter = new SqlEmployeeWriter();

            // ...
        }

        public void SaveEmployee(Employee e)
        {
            m_sqlEmployeeWriter.Save(e);
            
            // ...
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
