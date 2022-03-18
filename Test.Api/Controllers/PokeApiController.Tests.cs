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
            var response = await client.GetAsync(BASE_PATH + "/" + number);

            var actual = await response.DeserializeContentAsync<External.PokeApi.Models.Pokemon>();

            // assert
            Assert.AreEqual(number, actual.Id);
            Assert.AreEqual(expected, actual.Name);
        }
    }
}
