using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SIT313Project1.Modules;
using SIT313Project1.Utils;
using Newtonsoft.Json;

namespace SIT313Project1.Adapters
{
    public class AdapterFood : RecyclerView.Adapter, ItemClickListener
    {
        private List<Food> foods;
        private List<Order> orders;

        public AdapterFood(List<Food> foods)
        {
            orders = new List<Order>();
            this.foods = foods;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            FoodRecyclerViewHolder recyclerViewHolder = holder as FoodRecyclerViewHolder;
            Food food = foods[position];
            recyclerViewHolder.txt_food_name.Text = food.name;
            recyclerViewHolder.txt_food_price.Text = "$ " + food.price;
            int resourceId = (int)typeof(Resource.Drawable).GetField(food.img).GetValue(null);
            recyclerViewHolder.img_food_img.SetImageResource(resourceId);

            recyclerViewHolder.SetItemClickListener(this);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_food, parent, false);
            return new FoodRecyclerViewHolder(view);

        }

        public override int ItemCount
        {
            get { return foods.Count; }
        }

        public void OnClick(View itemView, int position)
        {
            // Toast.MakeText(itemView.Context,foods[position].name,ToastLength.Long).Show();
            View dialogView = LayoutInflater.From(itemView.Context).Inflate(Resource.Layout.userInputNumberDialog, null);
            Android.Support.V7.App.AlertDialog.Builder alertDialogBuilder = new Android.Support.V7.App.AlertDialog.Builder(itemView.Context);

            TextView dialog_food_name = dialogView.FindViewById<TextView>(Resource.Id.dialog_food_name);
            dialog_food_name.Text = foods[position].name;

            alertDialogBuilder.SetView(dialogView);

            string serve = dialogView.FindViewById<EditText>(Resource.Id.serveNum).Text;

            alertDialogBuilder.SetCancelable(false).SetPositiveButton("Confirm", delegate
                {
                    
                    EditText txt_serve_num = dialogView.FindViewById<EditText>(Resource.Id.serveNum);
                    Food food = foods[position];
                    if (string.IsNullOrEmpty(txt_serve_num.Text))
                    {
                        txt_serve_num.Error = "Required";
                    }
                    else
                    {
                        Order order = new Order(food.name, food.price, Int32.Parse(txt_serve_num.Text));
                        orders.Add(order);

                        // save file to local
                        var localOrders = Application.Context.GetSharedPreferences("MyOrders", FileCreationMode.Private);
                        var orderEdit = localOrders.Edit();

                        var json = JsonConvert.SerializeObject(orders);
                        orderEdit.PutString("orders", json);

                        orderEdit.Commit();

                        Toast.MakeText(itemView.Context, "Food added", ToastLength.Long).Show();
                    }
                })
                .SetNegativeButton("Cancel", delegate { alertDialogBuilder.Dispose(); });

            Android.Support.V7.App.AlertDialog alertDialog = alertDialogBuilder.Create();
            alertDialog.Show();

        }
    }

    public class FoodRecyclerViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        public TextView txt_food_name;
        public TextView txt_food_price;
        public ImageView img_food_img;
        public ItemClickListener iTemClickListener;

        public void SetItemClickListener(ItemClickListener iTemClickListener)
        {
            this.iTemClickListener = iTemClickListener;
        }
        public FoodRecyclerViewHolder(View itemView) : base(itemView)
        {
            this.txt_food_name = itemView.FindViewById<TextView>(Resource.Id.food_name);
            this.txt_food_price = itemView.FindViewById<TextView>(Resource.Id.food_price);
            this.img_food_img = itemView.FindViewById<ImageView>(Resource.Id.food_img);

            itemView.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            iTemClickListener.OnClick(v,AdapterPosition);
        }
    }

}