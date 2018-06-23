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
using CarDealer.Adapters;
using CarDealer.Core.Models;
using CarDealer.Core.Services;

namespace CarDealer
{
    [Activity(Label = "CarDealerMenuActivity", Icon = "@drawable/Icon")]
    public class CarDealerCarListActivity : Activity
    {
        private ListView carsListView;
        private List<Car> allCars;
        private CarDealerDataProvider carDealerDataProvider;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CarListView);

            carsListView = FindViewById<ListView>(Resource.Id.carsListView);

            carDealerDataProvider = new CarDealerDataProvider();

            allCars = carDealerDataProvider.GetAllCars();

            carsListView.Adapter = new CarDealerListAdapter(this, allCars);

            carsListView.ItemClick += CarListView_ItemClick;
        }

        private void CarListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var car = allCars[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(CarDetailsActivity));
            intent.PutExtra("selectedCarId", car.CarID);

            StartActivityForResult(intent, 100);
        }
    }
}