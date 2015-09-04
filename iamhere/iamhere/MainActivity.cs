using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iamhere
{
    [Activity(Label = "iamhere", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity//, ILocationListener
    {
        Location _currentLocation;
        LocationManager _locationManager;
        TextView _locationText;
        TextView _addressText;
        String _locationProvider;


        //
        Button signInBttn;
        //

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);
            SetContentView(Resource.Layout.signinPage);

            signInBttn = FindViewById<Button>(Resource.Id.SignIn);
            signInBttn.Click += SignInBttn_Click;


            //_addressText = FindViewById<TextView>(Resource.Id.address_text);
            //_locationText = FindViewById<TextView>(Resource.Id.location_text);
            //FindViewById<TextView>(Resource.Id.get_address_button).Click += AddressButton_OnClick;

            //InitializeLocationManager();
        }

        private void SignInBttn_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.clientPage);
        }

        //void InitializeLocationManager()
        //{
        //    _locationManager = (LocationManager)GetSystemService(LocationService);
        //    Criteria criteriaForLocationService = new Criteria
        //    {
        //        Accuracy = Accuracy.Fine
        //    };
        //    IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

        //    if (acceptableLocationProviders.Any())
        //    {
        //        _locationProvider = acceptableLocationProviders.First();
        //    }
        //    else
        //    {
        //        _locationProvider = String.Empty;
        //    }
        //}
        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
        //}
        //protected override void OnPause()
        //{
        //    base.OnPause();
        //    _locationManager.RemoveUpdates(this);
        //}
        //async void AddressButton_OnClick(object sender, EventArgs eventArgs)
        //{
        //    if (_currentLocation == null)
        //    {
        //        _addressText.Text = "Can't determine the current address.";
        //        return;
        //    }

        //    Geocoder geocoder = new Geocoder(this);
        //    IList<Address> addressList = await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

        //    Address address = addressList.FirstOrDefault();
        //    if (address != null)
        //    {
        //        StringBuilder deviceAddress = new StringBuilder();
        //        for (int i = 0; i < address.MaxAddressLineIndex; i++)
        //        {
        //            deviceAddress.Append(address.GetAddressLine(i))
        //                         .AppendLine(",");
        //        }
        //        _addressText.Text = deviceAddress.ToString();
        //    }
        //    else
        //    {
        //        _addressText.Text = "Unable to determine the address.";
        //    }
        //}

        //public void OnLocationChanged(Location location)
        //{
        //    _currentLocation = location;
        //    if (_currentLocation == null)
        //    {
        //        _locationText.Text = "Unable to determine your location.";
        //    }
        //    else
        //    {
        //        _locationText.Text = String.Format("{0},{1}", _currentLocation.Latitude, _currentLocation.Longitude);
        //    }
        //}

        //public void OnProviderDisabled(string provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnProviderEnabled(string provider)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
