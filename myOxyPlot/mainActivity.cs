using Android.App;
using Android.OS;
using Android.Hardware;
using System.Threading;

namespace myOxyPlot
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class mainActivity : Activity
    {
        private SensorManager _sensorManager;
        private Sensor _accelerometerSensor;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Thread.Sleep(4000);

            _sensorManager = (SensorManager)GetSystemService(SensorService);
            _accelerometerSensor = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);

            if (_accelerometerSensor != null)
                StartActivity(typeof(AxisChoiceActivity));
            else
                StartActivity(typeof(NotSupported));
        }
    }
}

