namespace Dependencies.Refactor.Exercises.CoffeeMug.Entities
{
    public class Coffeepot
    {
        private int MugsOfCoffeeRemaining { get; set; }

        public string State => MugsOfCoffeeRemaining > 0 ? "got coffee" : "empty";

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
