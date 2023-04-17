namespace webApi.Models
{
    public class ProductModel
    {
        public string product_code { get; set; }    
        public string product_name { get; set;}
        public double price { get; set;}

        public int product_remaining { get; set;}

        public int quantity_sold { get; set;}


    }
}
