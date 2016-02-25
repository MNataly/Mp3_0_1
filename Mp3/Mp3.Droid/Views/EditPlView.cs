using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Mp3.Droid.Views
{
    [Activity(Label = "Test")]
    public class EditPLView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.EditPLView);
            
        }
    }
}
