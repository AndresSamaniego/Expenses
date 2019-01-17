using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using PersonalExpenses.iOS.CustomerRenderers;
using Xamarin.Forms;

namespace PersonalExpenses.iOS.CustomerRenderers
{
    public class CustomTextCellRenderer : TextCellRenderer
    {
        public CustomTextCellRenderer()
        {
        }

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            switch (item.StyleId)
            {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;
                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;
                case "detail-disclosure-button":
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    break;
                case "disclosure-indicator":
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;
            }


            return cell;
        }
    }
}