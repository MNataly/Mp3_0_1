using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Mp3.Droid.Views
{
    [Activity(Label = "PlayList View")]
    public class PLView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PLView);
            //var messenger = Mvx.Resolve<IMvxMessenger>();
            //_token = messenger.Subscribe<MyMessageModel>(Play);
        }
    }
}