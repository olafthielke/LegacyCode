namespace Dependencies.Refactor.Exercises.CoffeeMug.Entities
{
    public class Coffee
    {
        public bool IsEmpty => SipsRemaining == 0;

        public int SipsRemaining { get; private set; }

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
            // A Coffee refill provides 3 sips of coffee
            SipsRemaining = 3;
        }
    }
}
