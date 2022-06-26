using System.Data.SqlClient;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Lab
{
    public static class GstProductSelector
    {
        public static decimal? SelectGstRate(Product product)
        {
            const string connString = "Server=tcp:prod.database.windows.net,1433;Initial Catalog=ProductGST;Persist Security Info=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=10;";

            decimal? gst = null;

            var conn = new SqlConnection(connString);
            conn.Open();

            // ...

            return gst;
        }
    }
}
