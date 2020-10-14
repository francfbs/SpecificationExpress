using SpecificationExpress.Tests.Assets.Models;
using SpecificationExpress.Tests.Assets.SpecificationsAsync;

namespace SpecificationExpress.Tests.Assets.ValidationsAsync
{
    public class SingleOrderValidationAsync : Validator<Order>
    {
        public SingleOrderValidationAsync(RepositoryAsync repository)
        {
            Add(new Rule<Order>(new ClientMustBeActiveAsync(repository), "Client must be active!"));
        }
    }
}