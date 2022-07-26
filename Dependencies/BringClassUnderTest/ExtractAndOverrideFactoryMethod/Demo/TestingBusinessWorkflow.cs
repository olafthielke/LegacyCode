using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public class TestingBusinessWorkflow : BusinessWorkflow
    {
        protected override IWorkflowOrchestrator BuildWorkflowOrchestrator()
        {
            return new MockWorkflowOrchestrator();
        }
    }


    public class MockWorkflowOrchestrator : IWorkflowOrchestrator
    {
        public void Init(string status)
        {
            // do nothing
        }
    }
}
