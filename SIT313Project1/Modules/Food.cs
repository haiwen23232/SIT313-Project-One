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
    public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string img { get; set; }
        public Food(int id, string name, double price, string img)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.img = img;
        }
    }
}