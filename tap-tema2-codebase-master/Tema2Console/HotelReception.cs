using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tema2Console
{
    public class HotelReception
    {
        public decimal FinalPrice { get; set; }

        public void ProcessOrder()
        {
            Console.WriteLine("Start processing...");

            Console.WriteLine("Loading order from file...");
            var dataJson = File.ReadAllText("orders.json");

            Console.WriteLine("Deserializing Order object from json data...");
            var order = JsonConvert.DeserializeObject<Order>(dataJson, new StringEnumConverter());

            if (order == null)
            {
                Console.WriteLine("Order type not parsed successfully.");
                return;
            }

            switch (order.Type)
            {
                case OrderType.Room:
                    Console.WriteLine("Processing Room order...");

                    Console.WriteLine("Validating order parameters...");

                    if (order.Quantity == 0)
                    {
                        Console.WriteLine("-Room order must specify Quantity");
                        return;
                    }

                    if (order.Price == 0)
                    {
                        Console.WriteLine("-Room order must specify Price");
                        return;
                    }

                    if (string.IsNullOrEmpty(order.ReservationDate))
                    {
                        Console.WriteLine("-Room order must specify Reservation Date");
                        return;
                    }

                    if (!DateTime.TryParseExact(order.ReservationDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var pasedReservationDate))
                    {
                        Console.WriteLine("-Reservation Date must be a valid date");
                        return;
                    }

                    if (pasedReservationDate < DateTime.Now.AddMonths(1))
                    {
                        FinalPrice = (order.Quantity * order.Price)* 0.9m;
                    }
                    else if (pasedReservationDate < DateTime.Now.AddMonths(2))
                    {
                        FinalPrice = (order.Quantity * order.Price) * 0.8m;
                    }
                    else
                    {
                        FinalPrice = order.Quantity * order.Price;
                    }
                    break;

                case OrderType.Product:
                    Console.WriteLine("Processing Product order...");

                    Console.WriteLine("Validating order parameters...");

                    if (string.IsNullOrEmpty(order.Name))
                    {
                        Console.WriteLine("-Product order must specify Name");
                        return;
                    }

                    if (order.Quantity == 0)
                    {
                        Console.WriteLine("-Product order must specify Quantity");
                        return;
                    }

                    if (order.Price == 0)
                    {
                        Console.WriteLine("-Product order must specify Price");
                        return;
                    }

                    var price = order.Quantity * order.Price;
                    if (order.Name == "Fanta")
                    {
                        price *= 0.75m;
                    }

                    FinalPrice = price;
                    break;

                case OrderType.Breakfast:
                    Console.WriteLine("Processing Breakfast order...");

                    Console.WriteLine("Validating order parameters...");

                    if (order.Quantity == 0)
                    {
                        Console.WriteLine("-Breakfast order must specify Quantity");
                        return;
                    }

                    if (order.Price == 0)
                    {
                        Console.WriteLine("-Breakfast order must specify Price");
                        return;
                    }

                    if (string.IsNullOrEmpty(order.ServingDate))
                    {
                        Console.WriteLine("-Room order must specify Serving Date");
                        return;
                    }

                    if (!DateTime.TryParseExact(order.ServingDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var pasedServingDate))
                    {
                        Console.WriteLine("-Serving Date must be a valid date");
                        return;
                    }

                    if (pasedServingDate < DateTime.Now.AddDays(7))
                    {
                        FinalPrice = order.Quantity * order.Price;
                    }
                    else
                    {
                        FinalPrice = (order.Quantity * order.Price) * 0.5m;
                    }
                    break;

                default:

                    Console.WriteLine("Unknown order type.");
                    break;
            }

            Console.WriteLine("Rating completed.");
        }
    }
}
