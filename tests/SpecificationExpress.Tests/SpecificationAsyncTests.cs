using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpecificationExpress.Tests.Assets;
using SpecificationExpress.Tests.Assets.Models;
using SpecificationExpress.Tests.Assets.Validations;
using SpecificationExpress.Tests.Assets.ValidationsAsync;
using Xunit;

namespace SpecificationExpress.Tests
{
    public class UnitTest2
    {
        [Fact]
        public async Task Single_SpecificationAsync_ShouldReturn_ErrorMessage()
        {
            //arrange invalid order, client is not active
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, "Monitor",2, 120), //monitor
                new OrderItem(7, "PenDrive",1, 5) 
            };
            var order = new Order(1, DateTime.Now, 3, orderItems);
            
            //act
            var result = await new SingleOrderValidationAsync(new RepositoryAsync()).ValidateAsync(order);
            
            //assert
            Assert.Single(result);
            Assert.Equal("Client must be active!", result[0].ErrorMessage);
            Assert.Equal("Order", result[0].EntityName);
        }
        
        
    }
}