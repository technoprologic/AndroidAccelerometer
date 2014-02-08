using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;

namespace myOxyPlot
{
    [Activity(Label = "myOxyPlot", MainLauncher = true, Icon = "@drawable/icon")]
    public class mainActivity : Activity
    {

        private SensorManager _sensorManager;
        private Sensor _accelerometerSensor;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _sensorManager = (SensorManager)GetSystemService(SensorService);
            _accelerometerSensor = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);

            if (_accelerometerSensor != null)
            {
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);

                // Place for 5 seconds delay
                StartActivity(typeof(AxisChoiceActivity));
            }
            else
            {
                // Device doesn't support accelerometer.
                SetContentView(Resource.Layout.SensorUnavailable); 
            }            
        }

        protected override void OnResume()
        {
            base.OnResume();
            ImageView imgView = FindViewById<ImageView>(Resource.Id.welcomImage);

            imgView.Click += delegate { StartActivity(typeof(AxisChoiceActivity)); };
        }
    }
}

