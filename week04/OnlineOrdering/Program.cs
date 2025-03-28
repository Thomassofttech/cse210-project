using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address usaAddress = new Address("102 Main St", "New York", "NY", "USA");
        Address nonUsaAddress = new Address("445 Oak Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Innocent", usaAddress);
        Customer customer2 = new Customer("Roseline Johnson", nonUsaAddress);

        // Create products
        Product product1 = new Product("Laptop", "P1001", 990.99, 1);
        Product product2 = new Product("Mouse", "P1002", 19.99, 2);
        Product product3 = new Product("Keyboard", "P1003", 46.90, 1);
        Product product4 = new Product("Monitor", "P1004", 188.95, 2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(new Product("Headphones", "P1005", 79.99, 1));

        // Display order information
        DisplayOrderDetails(order1);
        Console.WriteLine();
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order.CalculateTotalCost():0.00}");
    }
}