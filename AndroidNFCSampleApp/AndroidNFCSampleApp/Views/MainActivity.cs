using Android.OS;
using Android.App;
using Android.Nfc;
using Android.Content;

namespace AndroidNFCSampleApp
{
    [Activity(Label = "@string/app_name"/*, Theme = "@style/AppTheme"*/ /*, MainLauncher = true*/)]
    public class MainActivity : Activity
    {
        #region Fields
        private NfcAdapter nfcAdapter;
        #endregion

        #region LifeCycle
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            nfcAdapter = NfcAdapter.GetDefaultAdapter(this);
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (nfcAdapter == null)
            {
                var alert = new AlertDialog.Builder(this).Create();
                alert.SetMessage("NFC is not supported on this device.");
                alert.SetTitle("NFC Unavailable");
                alert.Show();
            }
            else
            {
                var tagDetected = new IntentFilter(NfcAdapter.ActionTagDiscovered);
                var filters = new[] { tagDetected };
                var intent = new Intent(this, this.GetType()).AddFlags(ActivityFlags.SingleTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);

                nfcAdapter.EnableForegroundDispatch(this, pendingIntent, filters, null);
            }
        }
        #endregion

        #region Actions
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            var alert = new AlertDialog.Builder(this).Create();
            alert.SetMessage("NFC tag discovered");
            alert.SetTitle("NFC");
            alert.Show();
        }
        #endregion
    }
}

