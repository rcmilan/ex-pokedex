using NUnit.Framework;
using System.Threading.Tasks;

namespace Test.Api.Controllers
{
    internal class PokeApiController
    {
        private const string BASE_PATH = "/api/pokeapi";


        [Test]
        [TestCase("mewtwo", 150)]
        public async Task Should_Get_Pokemon_By_Number(string expected, int number)
        {
            // arrange
            await using var application = new WebAppFactory("Development");
            var client = application.CreateClient();

            // act
            var response = await client.GetAsync(BASE_PATH + "?number=" + number);

            var actual = await response.DeserializeContentAsync<External.PokeApi.Models.Pokemon>();

            // assert
            Assert.AreEqual(number, actual.Id);
            Assert.AreEqual(expected, actual.Name);
        }

        [Test]
        [TestCase(151, "mew")]
        public async Task Should_Get_Pokemon_By_Name(int expected, string name)
        {
            // arrange
            await using var application = new WebAppFactory("Development");
            var client = application.CreateClient();

            // act
            var response = await client.GetAsync(BASE_PATH + "?name=" + name);

            var actual = await response.DeserializeContentAsync<External.PokeApi.Models.Pokemon>();

            // assert
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(expected, actual.Id);
        }
    }
}
