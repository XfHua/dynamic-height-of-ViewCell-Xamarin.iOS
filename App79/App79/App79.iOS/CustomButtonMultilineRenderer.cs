using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App79;
using App79.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(myButton), typeof(CustomButtonMultilineRenderer))]
namespace App79.iOS
{
    public class CustomButtonMultilineRenderer : ButtonRenderer
    {
        public CustomButtonMultilineRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
                this.Control.TitleEdgeInsets = new UIEdgeInsets(0, 10, 0, 10);
                this.Control.TitleLabel.TextAlignment = UITextAlignment.Center;
                this.Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                
            }
        }
    }
}