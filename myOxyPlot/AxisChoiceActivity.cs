
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;


namespace myOxyPlot
{
    [Activity(Theme = "@style/Theme.AxesChoice")]
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
            TextView dialog = FindViewById<TextView>(Resource.Id.dialog);

            button.Click += delegate
            {
                if (!boxX.Checked && !boxY.Checked && !boxZ.Checked)
                {
                    dialog.Text = "Please chose one or more axes";
                    dialog.SetTextColor(color: Android.Graphics.Color.Red);
                }
                else
                {
                    var activity = new Intent(this, typeof(Wykres));
                    activity.PutExtra("MyData", true);
                    activity.PutExtra("X", boxX.Checked);
                    activity.PutExtra("Y", boxY.Checked);
                    activity.PutExtra("Z", boxZ.Checked);
                    StartActivity(activity);
                }
            };
        }
    }
}