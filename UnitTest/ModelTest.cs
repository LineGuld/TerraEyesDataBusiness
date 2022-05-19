using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraEyes_BusinessServer.Models;
using Xunit;

namespace UnitTest
{
    public class ModelTest
    {
        [Fact]
        public void validUserInput()
        {
            throw new NotImplementedException();
        }

        [Theory] //Theory gør at den samme testmetode kan køre flre gange med forskellige parametre. Virker kun hvis det er den samme assertion de skal have.
        [InlineData (null)] //Hver inline data giver en variabel der skal bruges i testen, her er det 2 variable der ikke er valide som brugerid
        [InlineData ("")]
        public void invalidUseId(string userId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(userId));
        }
    }
}
