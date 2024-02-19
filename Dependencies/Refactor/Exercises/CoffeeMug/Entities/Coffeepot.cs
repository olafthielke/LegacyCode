using Dependencies.Refactor.Exercises.CoffeeMug.Interfaces;

namespace Dependencies.Refactor.Exercises.CoffeeMug.Entities
{
    public class Coffeepot : ICoffeepot
    {
        private int MugsOfCoffeeRemaining { get; set; }

        public string State => MugsOfCoffeeRemaining > 0 ? "got coffee" : "empty";

        public Coffeepot(int mugsOfCoffee)
        {
            MugsOfCoffeeRemaining = mugsOfCoffee;
        }

        public void Refill()
        {
            // ?
        }

        public virtual void Brew()
        {
            MugsOfCoffeeRemaining = 4;
        }
    }
}
