using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.XamarinAndroid;



namespace myOxyPlot
{
    [Activity(Label = "My Activity")]
    public class Wykres : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here

            SetContentView(Resource.Layout.Wykres);
            var plotView = FindViewById<PlotView>(Resource.Id.plotview);
            plotView.Model = new PlotModel("LineSeries") { LegendSymbolLength = 24 };
            var s1 = new LineSeries("Series 1")
            {
                Color = OxyColors.SkyBlue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.SkyBlue,
                MarkerStrokeThickness = 1.5
            };
            s1.Points.Add(new DataPoint(0, 10));
            s1.Points.Add(new DataPoint(10, 40));
            s1.Points.Add(new DataPoint(40, 20));
            s1.Points.Add(new DataPoint(60, 30));
            plotView.Model.Series.Add(s1);
        }
    }

      
}