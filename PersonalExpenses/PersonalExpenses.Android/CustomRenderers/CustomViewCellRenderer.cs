using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PersonalExpenses.Droid.CustomRenderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private bool _isSelected;
        private Android.Views.View _cell;

        public CustomViewCellRenderer()
        {
        }

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);

            _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
            _isSelected = false;

            return _cell;
        }
        
        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            var cell = sender as ViewCell;

            if (e.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;
                
                if (_isSelected)
                {
                    _cell.SetBackgroundColor(Color.FromHex("#8bd3cf").ToAndroid());
                }
                else
                {
                    _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
        }
    }

    public class CustomTextCellRenderer : TextCellRenderer
    {
        private bool _isSelected;
        private Android.Views.View _cell;

        public CustomTextCellRenderer()
        {
        }

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);

            _isSelected = false;

            _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);

            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            var cell = sender as TextCell;

            if (e.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;

                if (_isSelected)
                {
                     _cell.SetBackgroundColor(Color.FromHex("#8bd3cf").ToAndroid());
                }
                else
                {
                    _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
        }
    }
}