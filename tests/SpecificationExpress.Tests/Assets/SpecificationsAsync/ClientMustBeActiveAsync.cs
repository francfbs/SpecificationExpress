using System.Linq;
using System.Threading.Tasks;
using SpecificationExpress.Tests.Assets.Models;

namespace SpecificationExpress.Tests.Assets.SpecificationsAsync
{
    public class ClientMustBeActiveAsync : ISpecificationAsync<Order>
    {
        private readonly RepositoryAsync _repository;

        public ClientMustBeActiveAsync(RepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsSatisfiedBy(Order obj)
        {
            var client = (await _repository.GetClients()).FirstOrDefault(c => c.Id == obj.ClientId);;
            return client != null && client.Active;
        }
    }
}