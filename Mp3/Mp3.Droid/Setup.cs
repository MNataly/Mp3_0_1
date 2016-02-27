using Android.Content;
using Mp3.Core.Services;
using Mp3.Core.ViewModels;
using Mp3.Droid.Service;
using Mp3.Droid.Services;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace Mp3.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            //Mvx.RegisterType<IPlayMusicService>(()=> new DroidPlayMusicService());
            Mvx.RegisterType<ISoungsManagerService>(()=> new DroidSongsManagerService());
            Mvx.RegisterType<IGetMediaInfo>(()=> new DroidGetMediInfo());
        }

        //protected override void InitializeIoC()
        //{
        //    base.InitializeIoC();
        //    MvxAndroidSetup.
        //}
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
