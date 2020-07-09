using SpecificationExpress.Tests.Assets.Models;
using SpecificationExpress.Tests.Assets.Specifications;

namespace SpecificationExpress.Tests.Assets.Validations
{
    public class SingleOrderValidation : Validator<Order>
    {
        public SingleOrderValidation(Repository repository)
        {
            Add(new Rule<Order>(new ClientMustBeActive(repository), "Client must be active!"));
        }
    }
}