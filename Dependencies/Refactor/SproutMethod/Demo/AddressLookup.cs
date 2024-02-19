using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.Refactor.SproutMethod.Demo
{
    public static class AddressLookup
    {
        public static Address LookupAddress(int locationId)
        {
            var address = new Address();

            // ...

            return address;
        }
    }
}
