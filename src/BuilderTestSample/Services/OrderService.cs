using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            if (order.Id != 0) throw new InvalidOrderException("Order ID must be 0.");
            if (order.TotalAmount <= 0) throw new InvalidOrderException("Order amount must not be <= 0.");
            if (order.Customer == null ) throw new InvalidOrderException("Order must have a customer");
            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            if(customer.Id <= 0) throw new InvalidCustomerException("Customer.ID must not be <= 0");
            if(customer.HomeAddress == null ) throw new InvalidCustomerException("Customer address must not be null");  
            if(string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName)) 
            {
                throw new InvalidCustomerException("Customer First and Last name are required");
            }
                
            if(customer.CreditRating <= 200) throw new InsufficientCreditException("Customer Credit rating must be > 200");
            if(customer.TotalPurchases < 0) throw new InvalidCustomerException("Customer.TOtalPurchases must not be < 0");

            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {
            if(string.IsNullOrEmpty(homeAddress.Street1)) throw new InvalidAddressException("Address street 1 must have a value!");
            if(string.IsNullOrEmpty(homeAddress.City)) throw new InvalidAddressException("City must have a value!");
             if(string.IsNullOrEmpty(homeAddress.State)) throw new InvalidAddressException("state must have a value!");
            if(string.IsNullOrEmpty(homeAddress.PostalCode)) throw new InvalidAddressException("PostalCode must have a value!");
            
            // TODO: country is required (not null or empty)
        }

        private void ExpediteOrder(Order order)
        {
            // TODO: if credit rating > 500 and total purchases > 5000 set IsExpedited to true
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            // TODO: add the order to the customer

            // TODO: update the customer's total purchases property
        }
    }
}
