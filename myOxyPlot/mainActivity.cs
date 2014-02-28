using Android.App;
using Android.OS;
using Android.Hardware;
using Android.Widget;
using System.Threading;

namespace myOxyPlot
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory=true, Icon = "@drawable/icon")]
    public class mainActivity : Activity
    {
        private SensorManager _sensorManager;
        private Sensor _accelerometerSensor;
        static Thread thread;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            TextView dialog = FindViewById<TextView>(Resource.Id.TextView01);
            dialog.SetTextColor(Android.Graphics.Color.Orange);

            if (thread == null || thread.ThreadState == ThreadState.Stopped)
            {
                thread = new Thread(new ThreadStart(startMethod));
                thread.Start();
            }
        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }

        private void startMethod()
        {
            Thread.Sleep(4500);
            _sensorManager = (SensorManager)GetSystemService(SensorService);
            _accelerometerSensor = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);

            if (_accelerometerSensor != null)
                StartActivity(typeof(AxisChoiceActivity));
            else
                StartActivity(typeof(NotSupported));
            this.Finish();
        }

    }
}