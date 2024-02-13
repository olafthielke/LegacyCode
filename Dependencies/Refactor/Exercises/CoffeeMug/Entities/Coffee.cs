using Dependencies.Refactor.Exercises.CoffeeMug.Interfaces;

namespace Dependencies.Refactor.Exercises.CoffeeMug.Entities
{
    public class Coffee : ICoffee
    {
        public const int RefillSips = 3;

        public int SipsRemaining { get; private set; }

        public string State => SipsRemaining > 0 ? "got coffee" : "empty";

        public Coffee(int sips = 0)
        {
            SipsRemaining = sips;
        }

        public Coffee(bool fill)
        {
            if (fill)
                Refill();
        }

        public virtual void Drink()
        {
            SipsRemaining--;
        }

        public virtual void Refill()
        {
            SipsRemaining = RefillSips;
        }
    }
}
