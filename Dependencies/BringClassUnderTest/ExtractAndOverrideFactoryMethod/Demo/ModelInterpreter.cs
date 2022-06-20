using System.IO;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public class ModelInterpreter
    {
        private string _readings;

        public ModelInterpreter(decimal sen)
        {
            _readings = File.ReadAllText($"./models/cal_sen_{(int)(sen * 1000)}.json");

            // ...
        }
    }
}
