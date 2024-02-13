using Dependencies.Refactor.Exercises.CoffeeMug.Interfaces;

namespace Dependencies.Refactor.Exercises.CoffeeMug
{
    public class CoffeeDrinker
    {
        private IWork Work { get; }
        private ICoffee Coffee { get; }
        private ICoffeepot Coffeepot { get; }

        private bool Working => Work.TasksRemaining > 0;

        public CoffeeDrinker(IWork work, ICoffee coffee, ICoffeepot coffeepot)
        {
            Work = work;
            Coffee = coffee;
            Coffeepot = coffeepot;
        }

        public void Drink()
        {
            while (Working)
            {
                Coffee.Drink();
                Work.Execute();
                if (Coffee.State == "empty")
                {
                    if (Coffeepot.State == "empty")
                        Coffeepot.Brew();
                    Coffee.Refill();
                }
            }
        }
    }
}
