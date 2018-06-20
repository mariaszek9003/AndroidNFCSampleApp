using Android.OS;
using Android.App;
using Android.Nfc;
using Android.Content;
using Android.Nfc.Tech;

namespace AndroidNFCSampleApp.Views
{
    //[Activity(Label = "NFC2Activity"), IntentFilter(new[] { NfcAdapter.ActionTechDiscovered }, Categories = new[] { "android.intent.category.DEFAULT" })]
    [IntentFilter(new[] { NfcAdapter.ActionTechDiscovered }, Categories = new[] { "android.intent.category.DEFAULT" })]
    [MetaData(NfcAdapter.ActionTechDiscovered, Resource = "@xml/nfc_tech_list")]
    [Activity(Label = "NfcTechActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class NfcTechActivity : Activity
    {
        #region Fields
        private NfcAdapter nfcAdapter;
        #endregion

        #region LifeCycle
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_nfc_activity);

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
                var filters = new[]
                {
                    new IntentFilter(NfcAdapter.ActionTechDiscovered),
                    new IntentFilter(NfcAdapter.ActionTagDiscovered)
                };

                var techList = new string[][]
                {
                    new string[]
                    {
                        Java.Lang.Class.FromType(typeof(MifareClassic)).Name
                    },
                    new string[]
                    {
                        Java.Lang.Class.FromType(typeof(MifareUltralight)).Name
                    }
                };

                var intent = new Intent(this, this.GetType()).AddFlags(ActivityFlags.SingleTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);

                nfcAdapter.EnableForegroundDispatch(this, pendingIntent, filters, techList);
            }
        }
        #endregion

        #region Actions
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            var alert = new AlertDialog.Builder(this).Create();
            string tagId = TagParser.GetTagId(intent);
            alert.SetMessage("Tag Id: " + tagId);
            alert.SetTitle("NFC");
            alert.Show();
        }
        #endregion

    }
}