using Android.Content;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: ExportRenderer(typeof(Gaez.BakeryHouse.App.Controls.CustomLabel), typeof(Gaez.BakeryHouse.App.Platforms.Android.Renderers.CustomLabelRenderer))]
namespace Gaez.BakeryHouse.App.Platforms.Android.Renderers
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

            if (Control != null)
                Control.JustificationMode = global::Android.Text.JustificationMode.InterWord;
        }
    }
}
