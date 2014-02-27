using Android.App;
using Android.OS;
using System.Threading;

namespace myOxyPlot
{
    [Activity(Theme = "@style/Theme.NotSupported", NoHistory = true)]
    public class NotSupported : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Thread.Sleep(2000); 
        }
    }
}