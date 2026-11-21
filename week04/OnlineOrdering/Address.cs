public class Address
{
    // create private fields
    private string _street;
    private string _city; 
    private string _state;
    private string _country;

    // create public properties
    public string Street
    {
        get{return _street;}
        set{_street = value;}
    }

    public string City
    {
        get{return _city;}
        set{_city = value;}
    }

    public string State
    {
        get{return _state;}
        set{_state = value;}
    }

    public string Country
    {
        get{return _country;}
        set{_country = value;}
    }

    // create the constructor
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }


    // check if address is in Nigeria
    public bool IsInNigeria()
    {
        return _country.Equals(
            "Nigeria",
            System.StringComparison.OrdinalIgnoreCase
        );
    }

    // return the complete address
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {State}\n{_country}";
    }
}