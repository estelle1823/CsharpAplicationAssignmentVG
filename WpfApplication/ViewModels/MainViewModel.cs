using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApplication.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject _currentViewModel = null!;
}
