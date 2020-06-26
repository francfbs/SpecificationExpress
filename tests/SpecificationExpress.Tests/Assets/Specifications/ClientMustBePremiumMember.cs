using System.Linq;
using SpecificationExpress.Tests.Assets.Models;

namespace SpecificationExpress.Tests.Assets.Specifications
{
    public class ClientMustBePremiumMember : ISpecification<Order>
    {
        private readonly Repository _repository;

        public ClientMustBePremiumMember(Repository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Order obj)
        {
            var client = _repository.GetClients().FirstOrDefault(c => c.Id == obj.ClientId);
            return client != null && client.PremiumMember;
        }
    }
}