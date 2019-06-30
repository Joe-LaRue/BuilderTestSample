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
            var customer = _customerBuilder.WithTestValues().Id(0).Build();
            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(customer)
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

         [Fact]
         public void ThrowsExceptionGivenCustomerWithNoFirstAndLastName()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .FirstName("")
                                .LastName("")
                                .Build();

            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
         public void ThrowsExceptionGivenCustomerWithCreditRatingUnder200()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .CreditRating(200)
                                .Build();

            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(customer)
                            .Build();

            Assert.Throws<InsufficientCreditException>(() => _orderService.PlaceOrder(order));
        }

       
    }
}

