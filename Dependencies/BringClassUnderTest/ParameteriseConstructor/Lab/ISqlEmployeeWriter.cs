using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab
{
    public interface ISqlEmployeeWriter
    {
        void Save(Employee emp);
    }
}
