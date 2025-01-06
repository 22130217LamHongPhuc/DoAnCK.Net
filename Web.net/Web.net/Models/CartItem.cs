namespace Web.net.Models
{
    [Serializable]

    public class CartItem
    {

        
        public CartItem(string productId, string name, int price, int discountDefault, string thumbnail, int quality)
        {
            ProductID = productId;
            Name = name;
            Price = price;
            DiscountDefault = discountDefault;
            Thumbnail = thumbnail;
            Quatity = quality;
        }

        public string ProductID { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }


        public int DiscountDefault { get; set; }

        public string Thumbnail { get; set; }
        public int Quatity { get; set; }



        public int PriceAfterDiscount()
        {
            double percent = DiscountDefault / 100.0;

            int discount = (int) (percent * Price);

            return Price - discount;
        }

        public int TotalPriceCartItem()
        {
            return PriceAfterDiscount() * Quatity;
        }
    }
}
