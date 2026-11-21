public class Customer
{
    // create private fields
    private string _name;
    private Address _address;

    // create public properties
    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }

    public Address Address
    {
        get{return _address;}
        set{_address = value;}
    }

    // create the constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // check if the customer lives in Nigeria
    public bool IsInNigeria()
    {
        return _address.IsInNigeria();
    }
}