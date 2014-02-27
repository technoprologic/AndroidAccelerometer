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
    class Plot : PlotModel
    {
        public Plot(string plotTitle = "Default plot title", string axesX_Title = "x", string axesY_Title = "f(x)")
        {
            Title = plotTitle;
            Background = OxyColors.Black;
            PlotAreaBorderColor = OxyColors.Gray;
            TextColor = OxyColors.White;
            TitleColor = OxyColors.DarkOrange;
        }
    }
}