using System.Collections.Generic;
using SpecificationExpress.Tests.Assets.Models;
using SpecificationExpress.Tests.Assets.Specifications;

namespace SpecificationExpress.Tests.Assets.Validations
{
    public class ComplexOrderValidation : Validator<Order>
    {
        public ComplexOrderValidation(Repository repository, List<OrderItem> items)
        {
            Add(new Rule<Order>(new ClientMustBeActive(repository), "Client must be active!"));
            foreach (var item in items)
            {
                Add(new Rule<Order>(new ItemMustBeInStock(repository, item), $"Insufficient stock of the item {item.Description}."));
            }
        }
    }
}