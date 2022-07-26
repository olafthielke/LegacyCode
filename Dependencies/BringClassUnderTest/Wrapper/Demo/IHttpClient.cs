using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.Wrapper.Demo
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string requestUri);
    }
}
