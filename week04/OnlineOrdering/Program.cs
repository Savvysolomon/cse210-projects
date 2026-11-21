using System;

class Program
{
    static void Main (string[] args)
    {
        // first customer and order
        Address address1 = new Address(
            "20 SARS Road",
            "Obio Akpor",
            "Rivers State",
            "Nigeria"
        );

        Customer customer1 = new Customer(
            "Pascal Adams",
            address1
        );

        Order order1 = new Order(customer1);

        // create products for first order
        Product product1 = new Product(
            "Laptop", "P1001", 500m, 2
        );

        Product product2 = new Product(
            "Mouse", "P1002", 25m, 1
        );

        Product product3 = new Product(
            "Keyboard", "P1003", 40m, 3
        );

        // add products to the first order
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // second customer and order
        Address address2 = new Address(
            "45 King Street",
            "Toronto", 
            "Ontario",
            "Canada"
        );

        Customer customer2 = new Customer(
            "David Brown",
            address2
        );
        
        Order order2 = new Order(customer2);

        // create products for the second order
        Product product4 = new Product(
            "Headphones", "P1004", 80m, 1
        );

        Product product5 = new Product(
            "Notebook", "P1005", 15m, 2
        );


        // add products to the second order
        order2.AddProduct(product4);
        order2.AddProduct(product5);



        // display first order
        Console.WriteLine("=================================");
        Console.WriteLine("          FIRST ORDER");
        Console.WriteLine("=================================");

        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine(
            $"Total Cost: ${order1.GetTotalCost():F2}"
        );



        // display second order
        Console.WriteLine();

        Console.WriteLine("=================================");
        Console.WriteLine("          SECOND ORDER");
        Console.WriteLine("=================================");

        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}