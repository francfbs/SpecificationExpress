using SpecificationExpress.Tests.Assets.Models;
using SpecificationExpress.Tests.Assets.Specifications;

namespace SpecificationExpress.Tests.Assets.Validations
{
    public class MultipleOrderValidation : Validator<Order>
    {
        public MultipleOrderValidation(Repository repository)
        {
            Add(new Rule<Order>(new ClientMustBeActive(repository), "Client must be active!"));
            Add(new Rule<Order>(new ClientMustBePremiumMember(repository), "Client must be a premium member!"));
        }
    }
}