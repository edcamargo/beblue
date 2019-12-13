using AutoMoq;
using Beblue.Domain.Entities;
using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using Beblue.Services.Services;
using Bogus;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Beblue.Test
{
    [CollectionDefinition(nameof(UnitTestCollection))]
    public class UnitTestCollection : ICollectionFixture<UnitTestFixture> { }

    public class UnitTestFixture : IDisposable
    {
        public Mock<IDiscoRepository> DiscoRepositoryMock { get; set; }
        public Mock<IDiscoService> DiscoServiceMock { get; set; }

        public DiscoService GetDiscoService()
        {
            var mocker = new AutoMoqer();
            mocker.Create<DiscoService>();

            var discoService = mocker.Resolve<DiscoService>();

            DiscoRepositoryMock = mocker.GetMock<IDiscoRepository>();
            DiscoServiceMock = mocker.GetMock<IDiscoService>();

            return discoService;
        }

        public List<Disco> GetMixedDiscos()
        {
            var discos = new List<Disco>();

            discos.AddRange(GenerateDisco(4).ToList());

            return discos;
        }

        private static List<Disco> GenerateDisco(int number)
        {
            var DiscoTests = new Faker<Disco>("pt_BR")
                .RuleFor(c => c.Id, "1")
                .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
                .Generate(number);

            return DiscoTests;
        }

        public void Dispose()
        {
            // Dispose what you have!
        }
    }
}
