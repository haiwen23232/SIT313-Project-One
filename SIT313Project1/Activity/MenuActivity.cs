using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using SIT313Project1.Activity;
using SIT313Project1.Adapters;
using SIT313Project1.Modules;

namespace SIT313Project1
{
    [Activity(Label = "MenuActivity", Theme = "@style/AppTheme")]
    public class MenuActivity : Android.App.Activity
    {
        
        private List<Food> foodList;

        private RecyclerView foodRecyclerView;
        private RecyclerView.LayoutManager layoutManager;

        private Button place_order;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_menu);

            // clear shared preferences
            var localOrders = Application.Context.GetSharedPreferences("MyOrders", FileCreationMode.Private);
            var orderEdit = localOrders.Edit();
            orderEdit.Clear().Commit();

            SetupList();
            
            this.foodRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // create layout manager
            this.layoutManager = new LinearLayoutManager(this);
            this.foodRecyclerView.SetLayoutManager(this.layoutManager);
            AdapterFood adapterFood = new AdapterFood(foodList);
            this.foodRecyclerView.SetAdapter(adapterFood);

            this.place_order = FindViewById<Button>(Resource.Id.place_order_btn);
            this.place_order.Click += (obj, e) =>
            {
                Intent intent = new Intent(this, typeof(OrderActivity));
                this.StartActivity(intent);
            };

        }

        private void SetupList()
        {
            foodList = new List<Food>();
            foodList.Add(new Food(1, "Prawn Dumpling", 10.98, "prawn_dumpling"));
            foodList.Add(new Food(2, "Vegetarian Dumpling", 6.98, "vegetarian_dumpling"));
            foodList.Add(new Food(3, "BBQ Pork Bun", 7.98, "bbq_pork_bun"));
            foodList.Add(new Food(4, "Sticky Rice", 7.98, "sticky_rice"));
            foodList.Add(new Food(5, "Steamed Vegetables", 8.98, "steamed_vegetables"));
            foodList.Add(new Food(6, "Egg Yolk Bun", 8.98, "egg_yolk_bun"));
            foodList.Add(new Food(7, "Custard Bun", 6.98, "custard_bun"));
            foodList.Add(new Food(8, "Egg Tart", 8.98, "egg_tart"));
            foodList.Add(new Food(9, "Mango Pudding", 5.98, "mango_pudding"));
            foodList.Add(new Food(10, "Prawn Spring Roll", 9.98, "prawn_spring_roll"));
        }
    }
}