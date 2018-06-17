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

namespace AndroidNFCSampleApp.Views
{
    [Activity(Label = "FirstActivity", MainLauncher = true)]
    public class FirstActivity : Activity
    {
        #region Fields
        private Button buttonNFCStart;
        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_first_activity);

            buttonNFCStart = FindViewById<Button>(Resource.Id.buttonNFCStart);

            buttonNFCStart.Click += ButtonNFCStart_Click;
        }

        private void ButtonNFCStart_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}