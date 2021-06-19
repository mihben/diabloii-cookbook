using DiabloII_Cookbook.Client.Models;
using System.ComponentModel;

namespace DiabloII_Cookbook.Client.Services
{
    public interface ILoadingScreenService : INotifyPropertyChanged
    {
        LoadingScreenData Data { get; }
        bool IsLoading { get; set; }
    }
}
