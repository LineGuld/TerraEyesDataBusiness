using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.DBNetworking;
using Xunit;

namespace UnitTest
{
    public class APITests
    {
        IDbConnect db;

        APITests()
        {
            db = new DbConnection();
        }

        [Theory]
        [InlineData("XR1hpfucSxUvH4kXtZqUSX0Gv0T2")]
        public void TemperatureFromDbSuccesCode(string userId)
        {
            /// Aaaaargh jeg kan ikke finde ud af hvordan jeg tester at statuskoden bliver 200 :(
        }


    }
}
