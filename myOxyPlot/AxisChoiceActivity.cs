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


namespace myOxyPlot
{
    [Activity(Label = "Axes choice")]
    public class AxisChoiceActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Create your application here
            SetContentView(Resource.Layout.AxisChoice);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.ConfirmButton);

            CheckBox boxX = FindViewById<CheckBox>(Resource.Id.xAxisCheckBox);
            CheckBox boxY = FindViewById<CheckBox>(Resource.Id.yAxisCheckBox);
            CheckBox boxZ = FindViewById<CheckBox>(Resource.Id.zAxisCheckBox);

            button.Click += delegate
            {
                var plotActivity = new Intent(this, typeof(OxyPlotActivity));
                plotActivity.PutExtra("X", boxX.Checked);
                plotActivity.PutExtra("Y", boxY.Checked);
                plotActivity.PutExtra("Z", boxZ.Checked);
                StartActivity(typeof(Wykres));
            };
        }
    }
}