using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Constraints;
using Droid.Views;

namespace Droid
{
    [Activity(Label = "Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MainView mainView = new MainView(this);
            SetContentView(mainView);
        }
    }
}