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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PersonalExpenses.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ProgressBar), typeof(CustomProgressBarRenderer))]
[assembly: ExportRenderer(typeof(Xamarin.Forms.ViewCell), typeof(CustomViewCellRenderer))]
[assembly: ExportRenderer(typeof(Xamarin.Forms.TextCell), typeof(CustomTextCellRenderer))]
namespace PersonalExpenses.Droid.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressDrawable.SetTint(Color.FromHex("#e8ff59").ToAndroid());
            else if (e.NewElement.Progress == 0)
                Control.ProgressDrawable.SetTint(Color.FromHex("#cbe814").ToAndroid());
            else if (e.NewElement.Progress < .10)
                Control.ProgressDrawable.SetTint(Color.FromHex("#bedb04").ToAndroid());
            else if (e.NewElement.Progress < .20)
                Control.ProgressDrawable.SetTint(Color.FromHex("#b1cc04").ToAndroid());
            else if (e.NewElement.Progress < .30)
                Control.ProgressDrawable.SetTint(Color.FromHex("#9fb703").ToAndroid());
            else if (e.NewElement.Progress < .40)
                Control.ProgressDrawable.SetTint(Color.FromHex("#92a803").ToAndroid());
            else if (e.NewElement.Progress < .50)
                Control.ProgressDrawable.SetTint(Color.FromHex("#7e9102").ToAndroid());
            else if (e.NewElement.Progress < .60)
                Control.ProgressDrawable.SetTint(Color.FromHex("#6a7a01").ToAndroid());
            else if (e.NewElement.Progress < .70)
                Control.ProgressDrawable.SetTint(Color.FromHex("#5b6802").ToAndroid());
            else if (e.NewElement.Progress < .80)
                Control.ProgressDrawable.SetTint(Color.FromHex("#475101").ToAndroid());
            else if (e.NewElement.Progress < .90)
                Control.ProgressDrawable.SetTint(Color.FromHex("#333a01").ToAndroid());
            else
                Control.ProgressDrawable.SetTint(Color.FromHex("#1f2301").ToAndroid());

            Control.ScaleY = 2.0f;
        }
    }
}