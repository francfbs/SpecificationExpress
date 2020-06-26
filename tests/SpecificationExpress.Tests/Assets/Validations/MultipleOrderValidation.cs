using SpecificationExpress.Tests.Assets.Models;
using SpecificationExpress.Tests.Assets.Specifications;

namespace SpecificationExpress.Tests.Assets.Validations
{
    public class MultipleOrderValidation : Validator<Order>
    {
        public MultipleOrderValidation(Repository repository)
        {
            var clientMustBeActive = new ClientMustBeActive(repository);
            var clientMustBePremiumMember = new ClientMustBePremiumMember(repository);
            
            base.Add(new Rule<Order>(clientMustBeActive, "Client must be active!"));
            base.Add(new Rule<Order>(clientMustBePremiumMember, "Client must be a premium member!"));
        }
    }
}