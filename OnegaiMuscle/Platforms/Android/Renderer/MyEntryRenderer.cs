using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using OnegaiMuscle.CustomRenderer;
using OnegaiMuscle.Platforms.Android.Renderer;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(EntryCustomRenderer), typeof(MyEntryRenderer))]
namespace OnegaiMuscle.Platforms.Android.Renderer
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Color.Transparent);

            }
        }
    }
}
