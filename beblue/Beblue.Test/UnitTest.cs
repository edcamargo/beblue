using System;
using Xunit;

namespace Beblue.Test
{
    [Collection(nameof(UnitTestCollection))]
    public class UnitTest
    {
        public UnitTestFixture Fixture { get; set; }

        public UnitTest(UnitTestFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            var discoService = Fixture.GetDiscoService();
            //Fixture.DiscoRepositoryMock.Setup(c => c.GetById(1)).Returns(Fixture.GetMixedDiscos());

            var disco = discoService.GetAll();
        }
    }
}
