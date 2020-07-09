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
        [Fact]
        public void Single_Specification_ShouldReturn_ErrorMessage()
        {
            //arrange invalid order, client is not active
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, "Monitor",2, 120), //monitor
                new OrderItem(7, "PenDrive",1, 5) 
            };
            var order = new Order(1, DateTime.Now, 3, orderItems);
            
            //act
            var result = new SingleOrderValidation(new Repository()).Validate(order);
            
            //assert
            Assert.Single(result);
            Assert.Equal("Client must be active!", result[0].ErrorMessage);
            Assert.Equal("Order", result[0].EntityName);
        }
        
        [Fact]
        public void Single_Specification_ShouldNotReturn_Error()
        {
            //arrange valid order
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, "Monitor",2, 120), //monitor
                new OrderItem(7, "PenDrive",1, 5) 
            };
            var order = new Order(1, DateTime.Now, 1, orderItems);
            
            //act
            var result = new SingleOrderValidation(new Repository()).Validate(order);
            
            //assert
            Assert.Empty(result);
        }
        
        [Fact]
        public void Multiple_Specifications_ShouldReturn_ErrorMessages()
        {
            //arrange invalid order, client is not active and is not a premium member
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, "Monitor",2, 120), //monitor
                new OrderItem(7, "PenDrive",1, 5) 
            };
            var order = new Order(1, DateTime.Now, 3, orderItems);
            
            //act
            var result = new MultipleOrderValidation(new Repository()).Validate(order);
            
            //assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Client must be active!", result[0].ErrorMessage);
            Assert.Equal("Client must be a premium member!", result[1].ErrorMessage);
        }
        
        [Fact]
        public void Multiple_Specifications_ShouldNotReturn_Error()
        {
            //arrange a valid order
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, "Monitor",2, 120), //monitor
                new OrderItem(7, "PenDrive",1, 5) //pendrive
            };
            var order = new Order(1, DateTime.Now, 2, orderItems);
            
            //act
            var result = new MultipleOrderValidation(new Repository()).Validate(order);
            
            //assert
            Assert.Empty(result);
        }
        
        [Fact]
        public void Complex_Specification_ShouldReturn_ErrorMessage()
        {
            //arrange invalid order, client is not active and there's no sufficient stock of the items 
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, "Monitor", 2, 120), //monitor
                new OrderItem(7, "PenDrive",12, 5) //pendrive
            };
            var order = new Order(1, DateTime.Now, 3, orderItems);
            
            //act
            var result = new ComplexOrderValidation(new Repository(), order.Items).Validate(order);
            
            //assert
            Assert.Equal("Client must be active!", result[0].ErrorMessage);
            Assert.Equal("Insufficient stock of the item Monitor.", result[1].ErrorMessage);
            Assert.Equal("Insufficient stock of the item PenDrive.", result[2].ErrorMessage);
            
        }
        
        [Fact]
        public void Complex_Specification_ShouldNotReturn_Error()
        {
            //arrange valid order
            var orderItems = new List<OrderItem>()
            {
                new OrderItem(3, "Monitor", 1, 120), //monitor
                new OrderItem(7, "PenDrive",2, 5) //pendrive
            };
            var order = new Order(1, DateTime.Now, 2, orderItems);
            
            //act
            var result = new ComplexOrderValidation(new Repository(), order.Items).Validate(order);
            
            //assert
            Assert.Empty(result);
        }
    }
}