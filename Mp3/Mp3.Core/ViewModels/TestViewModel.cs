using System.Collections.Generic;
using System.Threading.Tasks;
using Mp3.Core.Services;
using MvvmCross.Core.ViewModels;

namespace Mp3.Core.ViewModels
{
    public interface IInitializeService
    {
        Task InitializeAsync();
    }
    public class TestViewModel : MvxViewModel
    {

        
        public TestViewModel()
        {
            
        }

        public async Task<DataMusic> LoadItemAsync(int prodId)
        {
            return await App.Connection.Table<DataMusic>().Where(x => x.Id == prodId).FirstOrDefaultAsync();
        }

        public async Task<List<DataMusic>> GetAllAsync()
        {
            return await App.Connection.Table<DataMusic>().ToListAsync();
        }

        public async Task UpdateAsync(DataMusic i)
        {
            await App.Connection.InsertOrReplaceAsync(i);
        }
        public async Task InsertAsync(DataMusic i)
        {
            await App.Connection.InsertAsync(i);
        }
    }
}
