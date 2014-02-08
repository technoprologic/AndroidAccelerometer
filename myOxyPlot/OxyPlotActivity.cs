using System;

using System.Text;
using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using Android.Runtime;
using Android.Views;


namespace myOxyPlot
{
    [Activity(Label = "Live Graph")]
    public class OxyPlotActivity : Activity, ISensorEventListener
    {
        private static readonly object _syncLock = new object();
        private SensorManager _sensorManager;
        private TextView _sensorTextView;
        private bool x, y, z;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.OxyPlot);
            _sensorManager = (SensorManager)GetSystemService(SensorService);
            _sensorTextView = FindViewById<TextView>(Resource.Id.accelerometer_text);
            x = Intent.GetBooleanExtra("X", true);
            y = Intent.GetBooleanExtra("Y", true);
            z = Intent.GetBooleanExtra("Z", true);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Ui);
        }

        protected override void OnPause()
        {
            base.OnPause();
            _sensorManager.UnregisterListener(this);
        }

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
            // We don't want to do anything here.
        }

        public void OnSensorChanged(SensorEvent e)
        {
            lock (_syncLock)
            {
                var text = new  StringBuilder();
                if(x)text.Append("x =").Append(e.Values[0]);
                if(y)text.Append(", y=").Append(e.Values[1]);
                if(z) text.Append(", z=").Append(e.Values[2]);

                _sensorTextView.Text = text.ToString();
            }
        }
    }
}