using SpecificationExpress.Tests.Assets.Models;
using SpecificationExpress.Tests.Assets.Specifications;

namespace SpecificationExpress.Tests.Assets.Validations
{
    public class SingleOrderValidation : Validator<Order>
    {
        public SingleOrderValidation(Repository repository)
        {
            var clientMustBeActive = new ClientMustBeActive(repository);
            
            base.Add(new Rule<Order>(clientMustBeActive, "Client must be active!"));
        }
    }
}