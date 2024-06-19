using JediApi.Models;
using JediApi.Repositories;
using JediApi.Services;
using Moq;
using System;

namespace JediApi.Tests.Services
{
    public class JediServiceTests
    {
        // não mexer
        private readonly JediService _service;
        private readonly Mock<IJediRepository> _repositoryMock;

        public JediServiceTests()
        {
            // não mexer
            _repositoryMock = new Mock<IJediRepository>();
            _service = new JediService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetById_Success()
        {
            var jedi = new Jedi
            {
                Id = 1,
                Name = "leia"
            };
            _repositoryMock.Setup(mock => mock.GetByIdAsync(jedi.Id)).ReturnsAsync(jedi);

            var novojedi = await _service.GetByIdAsync(jedi.Id);
            Assert.NotNull(novojedi);

            Assert.Equal(jedi.Id, novojedi.Id);
            Assert.Equal(jedi.Name, novojedi.Name);
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            var IdJedi = 1;
            _repositoryMock.Setup(mock => mock.GetByIdAsync(IdJedi)).ReturnsAsync((Jedi)null);
            var result = await _service.GetByIdAsync(IdJedi);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAll()
        {
            var anakin = new Jedi{  Id = 1, Name = "Anakin", Strength =100, Version = 12};
            var Yoda = new Jedi{Id = 2, Strength = 200, Name = "Yoda", Version = 3};
           var listadosjedi = new List<Jedi> { anakin , Yoda };
            _repositoryMock.Setup(mock => mock.GetAllAsync()).ReturnsAsync(listadosjedi);
            var jedis = await _service.GetAllAsync();

            Assert.NotNull(jedis);

            Assert.Equal(listadosjedi.Count, jedis.Count);
            Assert.Equal(listadosjedi[0].Id, jedis[0].Id);
            Assert.Equal(listadosjedi[1].Id, jedis[1].Id);
        }
    }
}
