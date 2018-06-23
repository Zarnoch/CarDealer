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
using CarDealer.Core.Models;
using Java.Lang;

namespace CarDealer.Adapters
{
    class CarDealerListAdapter : BaseAdapter
    {
        List<Car> items;
        Activity context;

        public CarDealerListAdapter(Activity context, List<Car> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override int Count => items.Count;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            if (convertView == null)            
                convertView = context.LayoutInflater.Inflate(Resource.Layout.CarRowView, null);
            
            convertView.FindViewById<ImageView>(Resource.Id.photoImageView).SetImageResource(Resource.Drawable.Icon);
            convertView.FindViewById<TextView>(Resource.Id.manufacturerText).Text = item.Manufacturer;
            convertView.FindViewById<TextView>(Resource.Id.modelText).Text = item.Model;
            convertView.FindViewById<TextView>(Resource.Id.priceText).Text = item.Price.ToString();

            return convertView;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
    }
}