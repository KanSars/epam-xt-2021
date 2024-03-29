﻿using System;

namespace Marketplace.Entities
{
    public class ProductInCart
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }

        public ProductInCart(int id, string title, int count)
        {
            Id = id;
            Title = title;
            Count = count;
        }
    }
}
