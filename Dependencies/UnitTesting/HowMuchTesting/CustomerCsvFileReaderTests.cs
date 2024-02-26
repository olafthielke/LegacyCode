namespace Dependencies.UnitTesting.HowMuchTesting
{
    public class CustomerCsvFileReaderTests
    {
        // Writing tests for ReadAllCustomers() method will involve some serious dependency breaking
        // for little gain, compared to the changes we want to make:
        // - File.ReadAllLines(customerFilePath) will try and read the hard-coded file path.
        // - CustomerAddressLookup.LookupAddress() is going to be a headache as well.
        // Not worth the effort!
    }
}
