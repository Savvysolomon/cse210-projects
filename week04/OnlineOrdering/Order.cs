using System.Collections.Generic;
using System.Text;

public class Order
{
    // create private fields
    private List<Product> _products;
    private Customer _customer;

    // create constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // add products to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // calculate the total cost of the order
    public decimal GetTotalCost()
    {
        decimal total = 0;

        foreach(Product product in _products)
        {
            total += product.GetTotalCost();
        }
        
        // add shipping cost once
        if (_customer.IsInNigeria())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    // generate the packing label
    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();

        label.AppendLine("PACKING LABEL");

        foreach(Product product in _products)
        {
            label.AppendLine(
                $"{product.Name} - {product.ProductId}"
            );
        }

        return label.ToString();
    }

    // generate shipping label
    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}