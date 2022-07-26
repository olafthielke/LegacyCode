namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public interface IWorkflowOrchestrator
    {
        void Init(string status);
    }

    public class WorkflowOrchestrator : IWorkflowOrchestrator
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
