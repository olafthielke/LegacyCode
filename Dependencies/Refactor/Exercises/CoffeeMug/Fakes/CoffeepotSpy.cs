using Dependencies.Refactor.Exercises.CoffeeMug.Entities;

namespace Dependencies.Refactor.Exercises.CoffeeMug.Fakes
{
    public class CoffeepotSpy : Coffeepot
    {
        public int BrewCallCount { get; private set; }

        public CoffeepotSpy(int mugsOfCoffee) 
            : base(mugsOfCoffee)
        { }

        public override void Brew()
        {
            BrewCallCount++;

            base.Brew();
        }
    }
}
