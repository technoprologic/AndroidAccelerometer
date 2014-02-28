using Android.App;
using Android.OS;
using System.Threading;

namespace myOxyPlot
{
    [Activity(Theme = "@style/Theme.NotSupported", NoHistory = true)]
    public class NotSupported : Activity
    {
       static Thread thread;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.SensorUnavailable);

            if (thread == null || thread.ThreadState == ThreadState.Stopped)
            {
                Thread.Sleep(3000);
            }
        }
    }
}