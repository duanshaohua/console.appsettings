using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ConsoleConfiguration
{
    public class TestService:ITestService
    {
        private readonly IConfiguration _configuration;
        public TestService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PrintMessage()
        {
            var section = _configuration.GetSection("Test");
            Console.WriteLine(section.Value);
        }
    }
}
