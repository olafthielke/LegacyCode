using MongoDB.Driver;
using System.Collections.Generic;

namespace Dependencies.Refactor.SproutMethod.Demo
{
    public class MongoDbConnector
    {
        public MongoDbConnector(string connString)
        {
            MongoClient dbClient = new MongoClient(connString);

            var dbList = dbClient.ListDatabases().ToList();

            // ... 
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            // ... 

            // Populate the list of employees from DB (somehow).


            return employees;
        }
    }
}
