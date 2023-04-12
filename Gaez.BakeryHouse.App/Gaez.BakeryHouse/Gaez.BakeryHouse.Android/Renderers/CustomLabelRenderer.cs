using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Gaez.BakeryHouse.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Gaez.BakeryHouse.Controls.CustomLabel), typeof(Gaez.BakeryHouse.Droid.Renderers.CustomLabelRenderer))]

namespace Gaez.BakeryHouse.Droid.Renderers
{
    [Obsolete]
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
                Control.JustificationMode = Android.Text.JustificationMode.InterWord;
        }
    }
}