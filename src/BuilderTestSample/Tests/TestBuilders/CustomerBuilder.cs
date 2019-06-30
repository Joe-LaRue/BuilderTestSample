using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
  public class CustomerBuilder
  {
    private readonly Customer _customer;

    Customer Build()
    {
      return _customer;
    }

    public CustomerBuilder WithTestValues()
    {
        
        return this;
    }
  }
}