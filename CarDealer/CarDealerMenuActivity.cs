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

namespace CarDealer
{
    [Activity(Label = "CarDealerMenuActivity", MainLauncher = true, Icon = "@drawable/Icon")]
    public class CarDealerMenuActivity : Activity
    {
        private Button buyButton;
        private Button aboutButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenuView);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            buyButton = FindViewById<Button>(Resource.Id.buyButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
        }

        private void HandleEvents()
        {
            aboutButton.Click += AboutButton_Click;
            buyButton.Click += BuyButton_Click;
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CarDealerCarListActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CarDealerAboutActivity));
            StartActivity(intent);
        }
    }
}