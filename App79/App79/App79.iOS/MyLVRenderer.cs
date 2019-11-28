using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using App79.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListView), typeof(MyLVRenderer))]
namespace App79.iOS
{
public class MyLVRenderer : ListViewRenderer
    {
        //UITableViewSource originalSource;
        
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            UITableViewSource originalSource = (UIKit.UITableViewSource)Control.Source;
            Control.Source = new MyLVSource(originalSource, e.NewElement);
            
        }
    }

    public class MyLVSource : UITableViewSource
    {
        UITableViewSource originalSource;

        ListView myListView;


        public MyLVSource(UITableViewSource origSource, ListView myListV)
        {
            originalSource = origSource;
            myListView = myListV;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return originalSource.RowsInSection(tableview, section);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            return originalSource.GetCell(tableView, indexPath);
        }

        public override nfloat GetHeightForFooter(UITableView tableView, nint section)
        {
            return originalSource.GetHeightForFooter(tableView, section);
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            nfloat origHeight = originalSource.GetHeightForRow(tableView, indexPath);

            // calculate your own row height here

            ObservableCollection<Employee> employees = myListView.ItemsSource as ObservableCollection<Employee>;

            string displayName = employees[indexPath.Row].DisplayName;

            nfloat height = MeasureTextSize(displayName,UIScreen.MainScreen.Bounds.Size.Width-50,UIFont.SystemFontSize,null);

            return height;
        }

        public nfloat MeasureTextSize(string text, double width, double fontSize, string fontName = null)
        {
            var nsText = new NSString(text);
            var boundSize = new SizeF((float)width, float.MaxValue);
            var options = NSStringDrawingOptions.UsesFontLeading | NSStringDrawingOptions.UsesLineFragmentOrigin;

            if (fontName == null)
            {
                fontName = "HelveticaNeue";
            }

            var attributes = new UIStringAttributes
            {
                Font = UIFont.FromName(fontName, (float)fontSize)
            };

            var sizeF = nsText.GetBoundingRect(boundSize, options, attributes, null).Size;

            //return new Xamarin.Forms.Size((double)sizeF.Width, (double)sizeF.Height);
            return sizeF.Height + 5;
        }
    }
}
