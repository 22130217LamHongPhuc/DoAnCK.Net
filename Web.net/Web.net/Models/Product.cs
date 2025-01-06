using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Net.Models;

    [Serializable]
public partial class Product
{

    public string ProductId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int DiscountDefault { get; set; }

    public string? Description { get; set; }

    public string? SubcategoryId { get; set; }

    public int QuanlityStock { get; set; }

    public int QuanlitySell { get; set; }

    public string Thumbnail { get; set; } = null!;

    public DateOnly CreateAt { get; set; }

    public Product() { }

    public Product(string productId, string name, int price, int discountDefault, string thumbnail)
    {
        ProductId = productId;
        Name = name;
        Price = price;
        DiscountDefault = discountDefault;
        Thumbnail = thumbnail;
    }

    public double getPriceAfterDiscount()

    {

        double percent = DiscountDefault / 100.0;

        double discount = percent*Price;

        return  Price - discount;
    }


    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();


    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();



    public virtual ICollection<ProductView> ProductViews { get; set; } = new List<ProductView>();




    public virtual Specification? Specification { get; set; }

    public virtual Subcategory? Subcategory { get; set; }




    public virtual ICollection<Subimage> Subimages { get; set; } = new List<Subimage>();
}
