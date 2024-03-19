namespace Tema2Console
{
    public class Order
    {
        public OrderType Type { get; set; }

        public int Quantity { get; set; }  
        
        public decimal Price { get; set; }   
        
        public string ReservationDate { get; set; }  
        
        public string Name { get; set; }   
        
        public string ServingDate { get; set; }     
    }
}
