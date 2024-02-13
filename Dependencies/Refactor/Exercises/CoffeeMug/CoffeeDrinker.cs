using Dependencies.Refactor.Exercises.CoffeeMug.Entities;

namespace Dependencies.Refactor.Exercises.CoffeeMug
{
    public class CoffeeDrinker
    {
        private Work Work { get; }
        private Coffee Coffee { get; }
        private Coffeepot Coffeepot { get; }

        public CoffeeDrinker(Work work, Coffee coffee, Coffeepot coffeepot)
        {
            Work = work;
            Coffee = coffee;
            Coffeepot = coffeepot;
        }

        // The 'CoffeeMug' function to refactor!
        public void Drink()
        {
            while (Work.IsInProgress)
            {
                PrepareCoffee();
                Coffee.Drink();
                Work.Execute();
            }
        }

        private void PrepareCoffee()
        {
            if (!Coffee.IsEmpty)
                return;
            if (Coffeepot.IsEmpty)
                Coffeepot.Brew();
            Coffee.Refill();
        }
    }
}
