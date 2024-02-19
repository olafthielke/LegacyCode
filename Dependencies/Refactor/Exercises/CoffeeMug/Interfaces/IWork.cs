namespace Dependencies.Refactor.Exercises.CoffeeMug.Interfaces
{
    public interface IWork
    {
        int TasksRemaining { get; }

        void Execute();
    }
}
