namespace Dependencies.Refactor.Exercises.CoffeeMug.Interfaces
{
    public interface ICoffeepot
    {
        string State { get; }

        public void Refill();
        public void Brew();
    }
}
