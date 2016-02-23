using System.Collections.Generic;
using System.Threading.Tasks;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;

namespace Mp3.Core.ViewModels
{
    
    public class TestViewModel : MvxViewModel
    {
        private readonly IDataService _dataService;
        
        public TestViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        
    }
}
