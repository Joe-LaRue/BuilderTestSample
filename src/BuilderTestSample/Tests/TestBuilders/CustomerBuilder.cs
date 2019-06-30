using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
  public class CustomerBuilder
  {
      public const int VALID_CUSTOMER_ID = 1;
    private Customer _customer;


    public Customer Build()
    {
      return _customer;
    }

    public CustomerBuilder Address(Address address)
    {
        _customer.HomeAddress = address;
        return this;
    }

    public CustomerBuilder WithTestValues()
    {       
        _customer = new Customer(VALID_CUSTOMER_ID);
        _customer.HomeAddress = new Address();
        return this;
    }
  }
}