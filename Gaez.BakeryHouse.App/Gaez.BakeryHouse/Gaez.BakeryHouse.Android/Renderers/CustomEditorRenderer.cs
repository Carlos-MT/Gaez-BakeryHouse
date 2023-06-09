﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Gaez.BakeryHouse.Controls.CustomEditor), typeof(Gaez.BakeryHouse.Droid.Renderers.CustomEditorRenderer))]
namespace Gaez.BakeryHouse.Droid.Renderers
{
    [Obsolete]
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}