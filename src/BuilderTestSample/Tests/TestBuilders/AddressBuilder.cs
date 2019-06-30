using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
  public class AddressBuilder
  {
    private Address _address = new Address();

    public Address Build()
    {
      return _address;
    }

    public AddressBuilder WithTestValues()
    {
        _address.City = "Boston";
        _address.Country = "USA";
        _address.PostalCode = "02210";
        _address.State = "MA";
        _address.Street1 = "123 Main St";
        _address.Street2 = "Unit 1";
        _address.Street3 = "3rd Floor";

        return this;
    }

    public AddressBuilder City(string city)
    {
        _address.City = city;
        return this;
    }

    public AddressBuilder State(string state)
    {
        _address.State = state;
        return this;
    }

    public AddressBuilder Country(string country)
    {
        _address.Country = country;
        return this;
    }

    public AddressBuilder PostalCode(string postalCode)
    {
        _address.PostalCode = postalCode;
        return this;
    }

    public AddressBuilder Street1(string street1)
    {
        _address.Street1 = street1;
        return this;
    }
  }
}