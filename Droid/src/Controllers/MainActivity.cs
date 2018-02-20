using Android.App;
using Android.OS;
using Android.Widget;
using Droid.Views;
using App.Shared;

namespace Droid
{
    [Activity(Label = "Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static readonly MainViewModel _mainViewModel = new MainViewModel();
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _mainViewModel.Load();
            MainView mainView = new MainView(this);
            SetContentView(mainView);
        }
    }
}