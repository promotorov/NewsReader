using System;
using System.Net.Mime;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Color = Android.Graphics.Color;

namespace Droid.Views
{
    class MainView: RelativeLayout
    {
        private NewsList _newsList;
        
        public MainView(Context context) : base(context)
        {
            _newsList = new NewsList(context);
            _newsList.SetBackgroundColor(Color.Green);
            
            AddView(_newsList);
        }
    }
}