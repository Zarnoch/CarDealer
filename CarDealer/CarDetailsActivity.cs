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
using CarDealer.Core.Services;

namespace CarDealer
{
    [Activity(Label = "CarDetailsActivity")]
    public class CarDetailsActivity : Activity
    {
        private ImageView carImage;
        private TextView carManufacturer;
        private TextView carModel;
        private TextView carDetails;

        private Car selectedCar;
        private CarDealerDataProvider dataProvider;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CarDetailsView);

            dataProvider = new CarDealerDataProvider();
            var selectedCarId = Intent.Extras.GetInt("selectedCarId");
            selectedCar = dataProvider.GetCarByID(selectedCarId);

            FindViews();
            BindData();
        }

        private void FindViews()
        {
            carImage = FindViewById<ImageView>(Resource.Id.imageView1);
            carManufacturer = FindViewById<TextView>(Resource.Id.manufacturerText);
            carModel = FindViewById<TextView>(Resource.Id.modelText);
            carDetails = FindViewById<TextView>(Resource.Id.descriptionText);
        }

        private void BindData()
        {
            carImage.SetImageResource(Resource.Drawable.logo);
            carManufacturer.Text = selectedCar.Manufacturer;
            carModel.Text = selectedCar.Model;
            carDetails.Text = selectedCar.Description;
        }
    }
}