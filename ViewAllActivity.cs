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

namespace ProjectOne
{
    [Activity(Label = "View All Users")]
    public class ViewAllActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Create your application here
            var userNames = Intent.Extras.GetStringArrayList("user_name") ?? new
            string[0];
            var userPassWords = Intent.Extras.GetStringArrayList("user_password") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, userNames);
            
        }
    }
}