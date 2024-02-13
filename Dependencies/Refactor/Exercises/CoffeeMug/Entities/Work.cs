namespace Dependencies.Refactor.Exercises.CoffeeMug.Entities
{
    public class Work
    {
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
