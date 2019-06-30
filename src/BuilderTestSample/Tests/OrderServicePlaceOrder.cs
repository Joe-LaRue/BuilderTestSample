using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly OrderBuilder _orderBuilder = new OrderBuilder();
        private readonly CustomerBuilder _customerBuilder = new CustomerBuilder();

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _orderBuilder
                            .WithTestValues()
                            .Id(123)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
         public void ThrowsExceptionGivenOrderWithZeroAmount()
        {
            var order = _orderBuilder
                            .WithTestValues()
                            .Amount(0)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
         public void ThrowsExceptionGivenOrderWithNullCustomer()
        {
            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(null)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
         public void ThrowsExceptionGivenCustomerWithZeroId()
        {
            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(new Customer(0))
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

          [Fact]
         public void ThrowsExceptionGivenCustomerWithNullAddress()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .Address(null)
                                .Build();

            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

       
    }
}

