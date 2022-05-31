using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sepet.Models
{
    public class CartItem
    {
        //bir alışveriş sepetinin .... si olur.

        public CartItem()
        {
            Quantity = 1;
        }
       
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }

       

        public decimal? SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}