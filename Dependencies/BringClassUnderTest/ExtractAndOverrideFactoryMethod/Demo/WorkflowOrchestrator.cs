namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public class WorkflowOrchestrator
    {
        private ModelInterpreter _interpreter;
        private SqlCustomerDatabase _customerDb;

        public WorkflowOrchestrator(ModelInterpreter interpreter, SqlCustomerDatabase customerDb)
        {
            _interpreter = interpreter;
            _customerDb = customerDb;
        }

        public void Init(string status)
        {
            // ...
        }
    }
}
