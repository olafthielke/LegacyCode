namespace Dependencies.Refactor.Exercises.CoffeeMug.Interfaces
{
    public interface ICoffee
    {
        public string State { get; }

        public void Drink();
        public void Refill();
    }
}
