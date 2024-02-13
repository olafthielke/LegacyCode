using Dependencies.Refactor.Exercises.CoffeeMug.Fakes;
using FluentAssertions;
using Xunit;

namespace Dependencies.Refactor.Exercises.CoffeeMug
{
    public class CoffeeDrinkerTests
    {
        [Fact]
        public void When_Not_Working_Then_Drink_No_Coffee_And_Do_No_Work()
        {
            const int numberOfWorkTasks = 0;    // Not working!
            var work = new WorkSpy(numberOfWorkTasks);
            var coffee = new CoffeeSpy(3);
            var drinker = new CoffeeDrinker(work, coffee, null);

            drinker.Drink();

            coffee.DrinkCallCount.Should().Be(0);
            work.ExecuteCallCount.Should().Be(0);
        }

        [Fact]
        public void When_Working_Then_Drink_Coffee_And_Do_Work()
        {
            const int numberOfWorkTasks = 1;    // Working!
            var work = new WorkSpy(numberOfWorkTasks);
            var coffee = new CoffeeSpy(3);
            var drinker = new CoffeeDrinker(work, coffee, null);

            drinker.Drink();

            coffee.DrinkCallCount.Should().Be(1);
            work.ExecuteCallCount.Should().Be(1);
        }

        [Fact]
        public void When_Coffee_Is_Empty_And_Coffeepot_Is_Full_Then_Refill_Coffee()
        {
            const int numberOfWorkTasks = 3;    // Working!
            var work = new WorkSpy(numberOfWorkTasks);
            var coffee = new CoffeeSpy(3);
            var coffeePot = new CoffeepotSpy(2);
            var drinker = new CoffeeDrinker(work, coffee, coffeePot);

            drinker.Drink();

            coffeePot.BrewCallCount.Should().Be(0);
            coffee.RefillCallCount.Should().Be(1);
            coffee.DrinkCallCount.Should().Be(3);
            work.ExecuteCallCount.Should().Be(3); 
        }

        [Fact]
        public void When_Coffee_Is_Empty_And_Coffeepot_Is_Empty_Then_Brew_Coffeepot_And_Refill_Coffee()
        {
            const int numberOfWorkTasks = 5;    // Working!
            var work = new WorkSpy(numberOfWorkTasks);
            var coffee = new CoffeeSpy(3);
            var coffeePot = new CoffeepotSpy(0);
            var drinker = new CoffeeDrinker(work, coffee, coffeePot);

            drinker.Drink();

            coffeePot.BrewCallCount.Should().Be(1);
            coffee.RefillCallCount.Should().Be(1);
            coffee.DrinkCallCount.Should().Be(5);
            work.ExecuteCallCount.Should().Be(5);
        }
    }
}
