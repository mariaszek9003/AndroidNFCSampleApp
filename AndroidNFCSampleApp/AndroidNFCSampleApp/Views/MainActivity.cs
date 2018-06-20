using System;
using Android.OS;
using Android.App;
using Android.Widget;

namespace AndroidNFCSampleApp.Views
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region Fields
        private Button buttonNfcNdefStart;
        private Button buttonNfcTechStart;
        private Button buttonNfcTagStart;
        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_main_activity);

            buttonNfcNdefStart = FindViewById<Button>(Resource.Id.buttonNfcNdefStart);
            buttonNfcTechStart = FindViewById<Button>(Resource.Id.buttonNfcTechStart);
            buttonNfcTagStart = FindViewById<Button>(Resource.Id.buttonNfcTagStart);

            buttonNfcNdefStart.Click += ButtonNfcNdefStart_Click;
            buttonNfcTechStart.Click += ButtonNfcTechStart_Click;
            buttonNfcTagStart.Click += ButtonNfcTagStart_Click;
        }

        private void ButtonNfcNdefStart_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NfcNdefActivity));
        }

        private void ButtonNfcTechStart_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NfcTechActivity));
        }

        private void ButtonNfcTagStart_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NfcTagActivity));
        }

    }
}