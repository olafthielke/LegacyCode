namespace Dependencies.Refactor.Exercises.CoffeeMug.Entities
{
    public class Coffeepot
    {
        public bool IsEmpty => MugsOfCoffeeRemaining == 0;

        private int MugsOfCoffeeRemaining { get; set; }

        public Coffeepot(int mugsOfCoffee)
        {
            MugsOfCoffeeRemaining = mugsOfCoffee;
        }

        public virtual void Brew()
        {
            // Brewing refills the Coffeepot with 4 mugs of coffee
            MugsOfCoffeeRemaining = 4;
        }
    }
}
