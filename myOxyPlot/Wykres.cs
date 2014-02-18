using System.Threading;
using Android.App;
using Android.OS;
using Android.Hardware;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.XamarinAndroid;

namespace myOxyPlot
{
    [Activity(Label = "Live plot", ScreenOrientation=Android.Content.PM.ScreenOrientation.Landscape)]
    public class Wykres : Activity, ISensorEventListener
    {
        private static readonly object _syncLock = new object();
        private SensorManager _sensorManager;
        private bool x, y, z;
        private double xVal, yVal, zVal;
        private int timeIntervalCounter = 0;
        LineSeries sX, sY, sZ;
        PlotModel model;
        PlotView plotView;
        string plotTitle = "Accelerometer";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Wykres);

            xVal = 0;
            yVal = 0;
            zVal = 0;
            x = Intent.GetBooleanExtra("X", false);
            y = Intent.GetBooleanExtra("Y", false);
            z = Intent.GetBooleanExtra("Z", false);

            _sensorManager = (SensorManager)GetSystemService(SensorService);
            plotView = FindViewById<PlotView>(Resource.Id.plotview);
            model = new PlotModel(plotTitle);
            
            if(x)
            {
                sX = new LineSeries("X Axis")
                {
                    Color = OxyColors.SkyBlue,
                    MarkerFill = OxyColors.SkyBlue,
                    MarkerStrokeThickness = 1.5
                };
                model.Series.Add(sX);
            }

            if(y)
            {
                sY = new LineSeries("Y Axis")
                {
                    Color = OxyColors.Red,
                    MarkerFill = OxyColors.Red,
                    MarkerStrokeThickness = 1.5
                };
                model.Series.Add(sY);
            }

            if (z)
            {
                sZ = new LineSeries("Z Axis")
                {
                    Color = OxyColors.Orange,
                    MarkerFill = OxyColors.Orange,
                    MarkerStrokeThickness = 1.5
                };
                model.Series.Add(sZ);  
            }
            
            plotView.Model = model;
            ThreadPool.QueueUserWorkItem(o => Draw());
        }

        protected override void OnResume()
        {
            base.OnResume();
            _sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Normal);
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
                xVal = e.Values[0];
                yVal = e.Values[1];
                zVal = e.Values[2];
            }
        }

        private void Draw()
        {
            while (true)
            {
                RunOnUiThread(delegate
                {
                    model.ResetAllAxes();
                    model.Annotations.Clear();
                    model.Series.Clear();
                    model = new PlotModel(plotTitle);
                    if (x)
                    {
                        sX.Points.Add(new DataPoint(timeIntervalCounter++, xVal));
                        model.Series.Add(sX);
                    }
                    if (y)
                    { 
                        sY.Points.Add(new DataPoint(timeIntervalCounter++, yVal));
                        model.Series.Add(sY);
                    }
                    if (z)
                    {
                        sZ.Points.Add(new DataPoint(timeIntervalCounter++, zVal));
                        model.Series.Add(sZ);
                    }
                    //if (timeIntervalCounter > 10)
                    //   model.DefaultXAxis.EndPosition = 20;
                    plotView.Model = model;
                });
                Thread.Sleep(1000);
            }
        }
    }
}