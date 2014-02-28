
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;


namespace myOxyPlot
{
    [Activity(Theme = "@style/Theme.AxesChoice", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AxisChoiceActivity : Activity
    {
        private bool flagX = false;
        private bool flagY = false;
        private bool flagZ = false;
        private Android.Graphics.Color boxCheckedColor = Android.Graphics.Color.Orange;
        private Android.Graphics.Color boxUncheckedColor = Android.Graphics.Color.Gray;
        private Android.Graphics.Color stupidOrWhat = Android.Graphics.Color.Red;

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
            button.SetBackgroundColor(boxCheckedColor);
            boxX.SetTextColor(boxUncheckedColor);
            boxY.SetTextColor(boxUncheckedColor);
            boxZ.SetTextColor(boxUncheckedColor);
            dialog.SetTextColor(boxCheckedColor);


            button.Click += delegate
            {
                if (!boxX.Checked && !boxY.Checked && !boxZ.Checked)
                {
                    dialog.SetTextColor(color: stupidOrWhat);
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

            boxX.CheckedChange += delegate
            {
                if (boxX.Checked)
                {
                    flagX = true;
                    dialog.SetTextColor(boxCheckedColor);
                    boxX.SetTextColor(boxCheckedColor);
                }
                else
                {
                    flagX = false;
                    boxX.SetTextColor(boxUncheckedColor);
                    if(!flagY && !flagZ)
                        dialog.SetTextColor(boxCheckedColor);
                }
            };

            boxY.CheckedChange += delegate
            {
                if (boxY.Checked)
                {
                    flagY = true;
                    dialog.SetTextColor(boxCheckedColor);
                    boxY.SetTextColor(boxCheckedColor);
                }
                else
                {
                    flagY = false;
                    boxY.SetTextColor(boxUncheckedColor);
                    if (!flagX && !flagZ)
                        dialog.SetTextColor(boxCheckedColor);
                }
            };

            boxZ.CheckedChange += delegate
            {
                if (boxZ.Checked)
                {
                    flagZ = true;
                    dialog.SetTextColor(boxCheckedColor);
                    boxZ.SetTextColor(boxCheckedColor);
                }
                else
                {
                    flagZ = false;
                    boxZ.SetTextColor(boxUncheckedColor);
                    if (!flagX && !flagZ)
                        dialog.SetTextColor(boxCheckedColor);
                }
            };

        }
    }
}