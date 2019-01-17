using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PersonalExpenses.iOS.CustomerRenderers;
using CoreGraphics;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomeProgressBarRenderer))]
namespace PersonalExpenses.iOS.CustomerRenderers
{
    public class CustomeProgressBarRenderer : ProgressBarRenderer
    {
        public CustomeProgressBarRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressTintColor = Color.FromHex("#000000").ToUIColor();
            else if (e.NewElement.Progress == 0)
                Control.ProgressTintColor = Color.FromHex("#362b4c").ToUIColor();
            else if (e.NewElement.Progress < .25)
                Control.ProgressTintColor = Color.FromHex("#1abf3e").ToUIColor();
            else if (e.NewElement.Progress < .50)
                Control.ProgressTintColor = Color.FromHex("#f7ca2a").ToUIColor();
            else if (e.NewElement.Progress < .75)
                Control.ProgressTintColor = Color.FromHex("#ef7e21").ToUIColor();
            else
                Control.ProgressTintColor = Color.FromHex("#8468ba").ToUIColor();


            
            LayoutSubviews();
        }


        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            float scaleX = 1.0f;
            float scaleY = 3.5f;

            var transform = CGAffineTransform.MakeScale(scaleX, scaleY);

            Transform = transform;
        }
    }
}