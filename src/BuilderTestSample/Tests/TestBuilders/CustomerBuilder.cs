using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
  public class CustomerBuilder
  {
    public const int VALID_CUSTOMER_ID = 1;
    public const string VALID_FIRST_NAME = "Bruce";
    public const string VALID_LAST_NAME = "Lee";
    

    private int _id;
    private string _firstName;
    private string _lastName;
    private Address _homeAddress;

    private Customer _customer;


    public Customer Build()
    {
        _customer = new Customer(_id)
        {
            HomeAddress = _homeAddress,
            FirstName = _firstName,
            LastName = _lastName
        };

      return _customer;
    }

    public CustomerBuilder Address(Address address)
    {
        _homeAddress = address;
        return this;
    }

    public CustomerBuilder Id(int id)
    {
        _id = id;
        return this;    
    }

    public CustomerBuilder FirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public CustomerBuilder LastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }
    

    public CustomerBuilder WithTestValues()
    {       
        _id = VALID_CUSTOMER_ID;
        _firstName = VALID_FIRST_NAME;
        _lastName = VALID_LAST_NAME;
        _homeAddress = new Address();        
        return this;
    }

    
  }
}