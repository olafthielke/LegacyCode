using Dependencies.Refactor.Exercises.CoffeeMug.Entities;

namespace Dependencies.Refactor.Exercises.CoffeeMug.Fakes
{
    public class WorkSpy : Work
    {
        public int ExecuteCallCount { get; private set; }

        public WorkSpy(int tasks) 
            : base(tasks)
        { }

        public override void Execute()
        {
            ExecuteCallCount++;

            base.Execute();
        }
    }
}
