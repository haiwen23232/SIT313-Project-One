using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SIT313Project1.Modules
{
    public class Order
    {
        public string food { get; set; }
        public double price { get; set; }
        public int serve { get; set; }

        public Order(string food, double price, int serve)
        {
            this.food = food;
            this.price = price;
            this.serve = serve;
        }
    }
}