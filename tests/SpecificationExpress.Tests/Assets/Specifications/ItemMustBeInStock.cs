using SpecificationExpress.Tests.Assets.Models;

namespace SpecificationExpress.Tests.Assets.Specifications
{
    public class ItemMustBeInStock : ISpecification<Order>
    {
        private readonly Repository _repository;
        private readonly OrderItem _item;

        public ItemMustBeInStock(Repository repository, OrderItem item)
        {
            _repository = repository;
            _item = item;
        }

        public bool IsSatisfiedBy(Order obj)
        {
            return _repository.GetProductById(_item.Id).Quantity >= _item.Quantity;
        }
    }
}