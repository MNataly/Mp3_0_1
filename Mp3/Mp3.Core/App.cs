using Mp3.Core.Services;
using Mp3.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace Mp3.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.MusicListViewModel>();
            Mvx.RegisterType<IMusicListViewModel>(() => new MusicListViewModel());
             
        }
    }
}
