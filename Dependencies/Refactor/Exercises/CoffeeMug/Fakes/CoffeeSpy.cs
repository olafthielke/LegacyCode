using Dependencies.Refactor.Exercises.CoffeeMug.Entities;

namespace Dependencies.Refactor.Exercises.CoffeeMug.Fakes
{
    public class CoffeeSpy : Coffee
    {
        public int DrinkCallCount { get; private set; }
        public int RefillCallCount { get; private set; }

        public CoffeeSpy(int sips) 
            : base(sips)
        { }

        public override void Drink()
        {
            DrinkCallCount++;

            base.Drink();
        }

        public override void Refill()
        {
            RefillCallCount++;

            base.Refill();
        }
    }
}
