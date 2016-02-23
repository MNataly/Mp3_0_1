using Mp3.Core.Services;
using Mp3.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using SQLite.Net.Async;

namespace Mp3.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        private IDataService _dataService;

        public static SQLiteAsyncConnection Connection { get; set; }
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.MusicListViewModel>();
            //Mvx.RegisterType<IMusicListViewModel>(() => new MusicListViewModel(IDataService dataServise));
             
        }
    }
}
