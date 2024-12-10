using System;
using System.Collections.Generic;

abstract class Product
{
    public string Name { get; protected set; }
    public decimal BasePrice { get; private set; }

    protected Product(string name, decimal basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public virtual decimal GetPrice()
    {
        return BasePrice;
    }

    public override string ToString()
    {
        return $"Product: {Name}, Price: {GetPrice()}";
    }
}

class Carrot : Product
{
    public Carrot(decimal basePrice) : base(name: "Carrot", basePrice: basePrice) { }
}


class Potato : Product
{
    public decimal Count { get; private set; }

    public Potato(decimal basePrice, decimal count) : base(name: "Potato", basePrice: basePrice)
    {
        Count = count;
    }

    public override decimal GetPrice()
    {
        return BasePrice * Count;
    }

    public override string ToString()
    {
        return $"Product: {Name}, Price: {BasePrice}, Count: {Count}, Total price: {GetPrice()}";
    }
}

class Cucumber : Product
{
    public decimal Count { get; private set; } 

    public Cucumber(decimal basePrice, decimal count) : base(name: "Cucumber", basePrice: basePrice)
    {
        Count = count;
    }

    public override decimal GetPrice()
    {
        return BasePrice * Count;
    }

    public override string ToString()
    {
        return $"Product: {Name}, Price: {BasePrice}, Count: {Count}, Total price: {GetPrice()}";
    }
}

class Tomato : Product
{
    public Tomato(decimal basePrice) : base(name: "Tomato", basePrice: basePrice) { }
}

class VegetableShop
{
    private List<Product> products = new List<Product>();

    public void AddProducts(IEnumerable<Product> newProducts)
    {
        products.AddRange(newProducts);
    }

    public void PrintProductsInfo()
    {
        decimal totalPrice = 0;

        foreach (var product in products)
        {
            Console.WriteLine(product);
            totalPrice += product.GetPrice();
        }

        Console.WriteLine($"Total products price: {totalPrice}");
    }
}

class Program
{
    static void Main()
    {
        var products = new List<Product>()
        {
            new Carrot(15),
            new Potato(20, 4),
            new Cucumber(14, 2)
        };

        VegetableShop shop = new VegetableShop();
        shop.AddProducts(products);

        shop.PrintProductsInfo();

    }
}

