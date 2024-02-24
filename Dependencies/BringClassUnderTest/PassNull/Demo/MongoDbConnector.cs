using MongoDB.Bson;
using MongoDB.Driver;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public class MongoDbConnector
    {
        private IMongoDatabase Db;
        private IMongoCollection<Employee> _employeesCollection;
        
        public MongoDbConnector(string connString)
        {
            MongoClient dbClient = new MongoClient(connString);

            Db = dbClient.GetDatabase("EmployeeDB");

            _employeesCollection = Db.GetCollection<Employee>("employees");
        }

        public Employee GetEmployee(int id)
        {
            var filter = Builders<Employee>.Filter.Eq("Id", id);
            return _employeesCollection.Find(filter).FirstOrDefault();
        }


        public Employee UpdateEmployee(Employee e)
        {
            var filter = Builders<Employee>.Filter.Eq("Id", e.Id);
            var update = Builders<Employee>.Update
                .Set("FirstName", e.FirstName)
                .Set("LastName", e.LastName)
                .Set("Email", e.Email)
                .Set("Salary", e.Salary)
                .Set("Status", e.Status)
                .Set("DepartmentId", e.DeptId);

            _employeesCollection.UpdateOne(filter, update);
            return GetEmployee(e.Id); // Return the updated employee
        }

        public Employee UpdateDepartmentStatus(int employeeId, int deptId, int status)
        {
            var filter = Builders<Employee>.Filter.Eq("DepartmentId", deptId);
            var update = Builders<Employee>.Update.Set("Status", status);

            _employeesCollection.UpdateMany(filter, update);
            
            return GetEmployee(employeeId);
        }
    }
}
