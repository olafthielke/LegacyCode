using System.Net.Http;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab_Hard
{
    public class InventoryChecker
    {
        public HttpClient _client = new HttpClient();

        private const string authToken = "rzipfwmeqsqrbiazztmbymktkbqhhiyiqemtejypexkbsaklniexsvwjv";

        private const string BaseUrl = "https://not-real-api.unleashedsoftware.com/v5/inventory?org=51270";


        public async Task<int> CheckAvailableStock(string itemId)
        {
            var result = await _client.GetStringAsync($"{BaseUrl}&sku={itemId}&authtoken={authToken}");

            int resultValue = 10;

            // ... JSON parsing and other processing

            return resultValue;
        }
    }
}
