namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public class BusinessWorkflow
    {
        private WorkflowOrchestrator Orchestrator { get; }

        public BusinessWorkflow()
        {
            var interpreter = new ModelInterpreter(AppConfig.GetCorrelationSensitivity());

            var customerDatabase = new SqlCustomerDatabase(AppConfig.GetConnectionString());

            Orchestrator = new WorkflowOrchestrator(interpreter, customerDatabase);

            Orchestrator.Init("STATUS_ACTIVE");

            // ...
        }
    }
}
