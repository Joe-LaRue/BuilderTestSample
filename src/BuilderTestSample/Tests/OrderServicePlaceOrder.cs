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
        private readonly AddressBuilder _addressBuilder = new AddressBuilder();

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

         [Fact]
         public void ThrowsExceptionGivenCustomerWithTOtalPurchasesLessThan0()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .TotalPurchases(-1)
                                .Build();

            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }   

         [Theory]
         [InlineData("")]
         [InlineData(null)]
         public void ThrowsExceptionGivenAddressHasEmptyStreet1(string street1)
        {
                                
            var address = _addressBuilder
                            .WithTestValues()
                            .Street1(street1)
                            .Build();

            var customer = _customerBuilder
                                .WithTestValues()
                                .Address(address)
                                .Build();            

            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }   

         [Theory]
         [InlineData("")]
         [InlineData(null)]
         public void ThrowsExceptionGivenAddressHasEmptycity(string city)
        {
                                
            var address = _addressBuilder
                            .WithTestValues()
                            .City(city)
                            .Build();

            var customer = _customerBuilder
                                .WithTestValues()
                                .Address(address)
                                .Build();            

            var order = _orderBuilder
                            .WithTestValues()
                            .Customer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }   

       
    }
}

