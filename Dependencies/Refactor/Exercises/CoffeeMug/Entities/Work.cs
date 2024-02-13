namespace Dependencies.Refactor.Exercises.CoffeeMug.Entities
{
    public class Work
    {
        public bool IsInProgress => TasksRemaining > 0;

        public int TasksRemaining { get; private set; }

        public Work(int tasks)
        {
            TasksRemaining = tasks;
        }

        public virtual void Execute()
        { 
            TasksRemaining--;
        }
    }
}
