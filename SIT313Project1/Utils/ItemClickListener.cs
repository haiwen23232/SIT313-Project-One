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

namespace SIT313Project1.Utils
{
    public interface ItemClickListener
    {
        void OnClick(View itemView, int position);
    }
}