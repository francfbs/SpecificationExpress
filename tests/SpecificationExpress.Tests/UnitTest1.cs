using System;
using System.Collections.Generic;
using SpecificationExpress.Tests.Assets;
using SpecificationExpress.Tests.Assets.Models;
using SpecificationExpress.Tests.Assets.Validations;
using Xunit;

namespace SpecificationExpress.Tests
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Single Specification Return ErrorMessage")]
        public void Single_Specification_ShouldReturn_ErrorMessage()
        {
            //arrange
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, 2, 120), //monitor
                new OrderItem(7, 1, 5) //pendrive
            };
            var order = new Order(1, DateTime.Now, 3, orderItems);
            
            //act
            var result = new SingleOrderValidation(new Repository()).Validate(order);
            
            //assert
            Assert.Single(result);
            Assert.Equal("Client must be active!", result[0].ErrorMessage);
            Assert.Equal("Order", result[0].EntityName);
        }
        
        [Fact(DisplayName = "Single Specification No Return Error")]
        public void Single_Specification_ShouldNotReturn_Error()
        {
            //arrange
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, 2, 120), //monitor
                new OrderItem(7, 1, 5) //pendrive
            };
            var order = new Order(1, DateTime.Now, 1, orderItems);
            
            //act
            var result = new SingleOrderValidation(new Repository()).Validate(order);
            
            //assert
            Assert.Empty(result);
        }
        
        [Fact(DisplayName = "Multiple Specifications Return ErrorMessages")]
        public void Multiple_Specifications_ShouldReturn_ErrorMessages()
        {
            //arrange
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, 2, 120), //monitor
                new OrderItem(7, 1, 5) //pendrive
            };
            var order = new Order(1, DateTime.Now, 3, orderItems);
            
            //act
            var result = new MultipleOrderValidation(new Repository()).Validate(order);
            
            //assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Client must be active!", result[0].ErrorMessage);
            Assert.Equal("Client must be a premium member!", result[1].ErrorMessage);
        }
        
        [Fact(DisplayName = "Multiple Specifications No Return Error")]
        public void Multiple_Specifications_ShouldNotReturn_Error()
        {
            //arrange
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, 2, 120), //monitor
                new OrderItem(7, 1, 5) //pendrive
            };
            var order = new Order(1, DateTime.Now, 2, orderItems);
            
            //act
            var result = new MultipleOrderValidation(new Repository()).Validate(order);
            
            //assert
            Assert.Empty(result);
        }
    }
}