using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Net.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int? DiscountDefault { get; set; }

    public string? Description { get; set; }

    public string? SubcategoryId { get; set; }

    public int QuanlityStock { get; set; }

    public int QuanlitySell { get; set; }

    public string Thumbnail { get; set; } = null!;

    public DateOnly CreateAt { get; set; }


    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();


    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();



    public virtual ICollection<ProductView> ProductViews { get; set; } = new List<ProductView>();




    public virtual Specification? Specification { get; set; }

    public virtual Subcategory? Subcategory { get; set; }




    public virtual ICollection<Subimage> Subimages { get; set; } = new List<Subimage>();
}
