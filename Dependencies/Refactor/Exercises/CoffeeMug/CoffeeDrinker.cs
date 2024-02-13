using Dependencies.Refactor.Exercises.CoffeeMug.Entities;

namespace Dependencies.Refactor.Exercises.CoffeeMug
{
    public class CoffeeDrinker
    {
        private Work Work { get; }
        private Coffee Coffee { get; }
        private Coffeepot Coffeepot { get; }

        private bool Working => Work.TasksRemaining > 0;

        public CoffeeDrinker(Work work, Coffee coffee, Coffeepot coffeepot)
        {
            Work = work;
            Coffee = coffee;
            Coffeepot = coffeepot;
        }

        // The 'CoffeeMug' function to refactor!
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
