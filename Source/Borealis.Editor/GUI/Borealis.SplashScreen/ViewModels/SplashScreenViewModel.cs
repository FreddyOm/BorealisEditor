using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Borealis.SplashScreen.ViewModels;

public partial class SplashScreenViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial int LoadingProgress { get; set; } = 0;

    public SplashScreenViewModel()
    {
        Task.Run(async () => await LoadEngine().ConfigureAwait(false));
    }
    
    private async Task LoadEngine()
    {
        for (var i = 0; i <= 100; i += 1)
        {
            await Task.Delay(20);
            LoadingProgress = i;
            OnPropertyChanged(nameof(LoadingProgress));
        }
    }
}
