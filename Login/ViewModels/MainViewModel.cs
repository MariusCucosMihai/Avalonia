using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Login.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Benvenuto! Effettua il login per continuare";
    [ObservableProperty] public partial string ErrorMessage { get; set; } = "";
    
    private bool logged;

    [ObservableProperty] public partial string Name { get; set; } = "";

    public string StatusLogin => logged ? "Logout" : "Login";

    [RelayCommand]
    private void Login()
    {

        if (string.IsNullOrWhiteSpace(Name))
        {
            ErrorMessage = "Il campo nome non può essere nullo";
            return;
        }
        logged = !logged;

        ErrorMessage = "";
        Greeting = logged ? $"Benvenuto {Name}!" : $"Arrivederci {Name}!";
        
        OnPropertyChanged(nameof(StatusLogin));
    }
}