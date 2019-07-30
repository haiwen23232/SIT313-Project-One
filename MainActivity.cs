using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace ProjectOne
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly List<string> userNames = new List<string>();
        static readonly List<string> userPassWords = new List<string>();
        //more code…
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Button viewAllButton = FindViewById<Button>(Resource.Id.ViewAllButton);
            Button saveButton = FindViewById<Button>(Resource.Id.SaveButton);
            TextView name = FindViewById<EditText>(Resource.Id.nameText);
            TextView password = FindViewById<EditText>(Resource.Id.passwordText);

            viewAllButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(ProjectOne.ViewAllActivity));
                intent.PutStringArrayListExtra("user_name", userNames);
                intent.PutStringArrayListExtra("user_password", userPassWords);
                StartActivity(intent);
            };

            saveButton.Click += (sender, e) =>
            {
                string newName = "";
                string newPassWord = "";
                if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(password.Text))
                {
                    newName = "";
                    newPassWord = "";
                }
                else
                {
                    userNames.Add(name.Text);
                    userPassWords.Add(password.Text);
                }
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

