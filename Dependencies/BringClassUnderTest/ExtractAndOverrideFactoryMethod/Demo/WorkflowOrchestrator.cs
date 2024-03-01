using System;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public class WorkflowOrchestrator
    {
        private ModelInterpreter _interpreter;
        private SqlCustomerDatabase _customerDb;

        public WorkflowOrchestrator(ModelInterpreter interpreter, SqlCustomerDatabase customerDb)
        {
            _interpreter = interpreter;
            if (_interpreter == null)
                throw new InvalidOperationException("Must have a valid ModelInterpreter.");

            _customerDb = customerDb;
            if (_customerDb == null)
                throw new InvalidOperationException("Must have a valid SqlCustomerDatabase.");
        }

        public void Init(string status)
        {
            // ...
        }
    }
}
