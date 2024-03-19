//*Single Responsibility Principle (SRP): Am separat responsabilitatile intre diferitele clase (OrderLoader, OrderProcessor, PriceCalculator), fiecare avand o singura responsabilitate.
//Open / Closed Principle(OCP): Am folosit interfete pentru a defini contractele, permitand extinderea comportamentului prin implementarea de noi interfete fara a modifica codul existent.
//Liskov Substitution Principle (LSP): Nu este aplicabil in mod direct in codul dat, deoarece nu folosim mostenire in acest context.
//Interface Segregation Principle (ISP): Am creat interfete specifice pentru fiecare functionalitate, astfel incat clientii sa nu fie obligati sa implementeze metode pe care nu le folosesc.
//Dependency Inversion Principle (DIP): Am folosit injecția de dependențe in metoda Main, unde cream instante ale interfetelor si nu ale claselor concrete, permitand flexibilitate si usurinta in testare si schimbare.*//
// Interfaces for our functionalities
using Tema2Console;

public interface IOrderLoader
{
    // Method for loading an order from a file
    Order LoadOrderFromFile(string filename);
}

public interface IOrderProcessor
{
    // Method for processing an order
    void ProcessOrder(Order order);
}

public interface IPriceCalculator
{
    // Method for calculating the final price of an order
    decimal CalculateFinalPrice(Order order);
}

// Class responsible for order processing
public class OrderProcessor : IOrderLoader, IOrderProcessor
{
    // Implementation for loading orders from file
    public Order LoadOrderFromFile(string filename)
    {
        // Implementation for loading orders from file
    }

    // Implementation for processing orders
    public void ProcessOrder(Order order)
    {
        // Implementation for processing orders
    }
}

// Class responsible for calculating the final price of orders
public class PriceCalculator : IPriceCalculator
{
    // Implementation for calculating the final price of orders
    public decimal CalculateFinalPrice(Order order)
    {
        // Implementation for calculating the final price of orders
    }
}

// Main class
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Client...");

        // Creating instances of interfaces with their concrete implementations
        IOrderLoader orderLoader = new OrderProcessor();
        IOrderProcessor orderProcessor = new OrderProcessor();
        IPriceCalculator priceCalculator = new PriceCalculator();

        // Loading the order from file
        var order = orderLoader.LoadOrderFromFile("orders.json");
        if (order != null)
        {
            // Processing the order
            orderProcessor.ProcessOrder(order);
            // Calculating the final price
            var finalPrice = priceCalculator.CalculateFinalPrice(order);
            if (finalPrice == 0)
            {
                Console.WriteLine("No order was processed.");
            }
            else
            {
                Console.WriteLine($"Final price for your order: {finalPrice} RON");
            }
        }
    }
}
