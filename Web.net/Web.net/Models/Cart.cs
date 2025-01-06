
using API.Net.Models;
using System.Xml.Linq;


namespace Web.net.Models
{
    public class Cart
    {
        public int fee { get; set; } = 10000;
        public int discount { get; set; }  = 0;

        public Dictionary<string, CartItem> carts { get; set; }
        public Cart()
        {
            carts = new Dictionary<string, CartItem>();
        }

        public void AddCartItem(Product p,int quantity) 
        {
           

            if (carts.ContainsKey(p.ProductId))
            {
                carts[p.ProductId].Quatity+= quantity;

            }
            else
            {
                carts.Add(p.ProductId, new CartItem(p.ProductId, p.Name, p.Price,p.DiscountDefault, p.Thumbnail,quantity));

            }
        }



        public void UpdateQuantity(string productId, int quantity)
        {

            if (carts != null && carts.ContainsKey(productId))
            {
                  carts[productId].Quatity = quantity;
            }
        }

        public void RemoveCartItem(string productId)
        {

            if (carts != null && carts.ContainsKey(productId))
            {
                carts.Remove(productId);
            }


        }

        public int TotalPriceCart()
        {
            return carts.Sum(c => c.Value.TotalPriceCartItem());
        }
        public int totalPriceUseVoucher()
        {
            return TotalPriceCart() - discount;
        }

        public double TotalPriceCartAddFee()
        {
            return TotalPriceCart() + 10000;
        }

        public void SetDiscount(Voucher voucher)
        {
           

            if (voucher.TypeId == 1) 
            {
                int valueDiscount =  (int) (TotalPriceCart()*voucher.VoucherPercent / 100.00) ;

                this.discount = (int) (valueDiscount > voucher.MaximumValue ? voucher.MaximumValue : valueDiscount);
            }
            else 
            {
                this.discount = (int) (voucher.VoucherCash ?? 0);
            }


        }


        public List<CartItem> getAllCartItem()
        {
            List<CartItem> cartItems = new List<CartItem>();

            foreach (CartItem i in carts.Values)
            {
                cartItems.Add(i);
            }

            return cartItems;

        }

        public int CartSize()
        {
            return carts.Count();
        }
        public void clearCart()
        {
            carts.Clear();
        }




    }
}
