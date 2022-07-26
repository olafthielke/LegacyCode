namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public class BusinessWorkflow
    {
        private IWorkflowOrchestrator Orchestrator { get; }

        public BusinessWorkflow()
        {
            Orchestrator = BuildWorkflowOrchestrator();

            Orchestrator.Init("STATUS_ACTIVE");

            // ...
        }

        protected virtual IWorkflowOrchestrator BuildWorkflowOrchestrator()
        {
            var interpreter = new ModelInterpreter(AppConfig.GetCorrelationSensitivity());

            var customerDatabase = new SqlCustomerDatabase(AppConfig.GetConnectionString());

            return new WorkflowOrchestrator(interpreter, customerDatabase);
        }
    }
}
