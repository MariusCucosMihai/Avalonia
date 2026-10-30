using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Login.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Benvenuto! Effettua il login per continuare";
    [ObservableProperty] public partial string ErrorMessage { get; set; } = "";

    [ObservableProperty] public partial string Password { get; set; } = "";
    
    [ObservableProperty] public partial List<string> NameList { get; set; } = new List<string>() {"marius", "thomas", "fabrizio", "nicola", "diego", "federico", "roberto"};
    
    [ObservableProperty] public partial List<string> PasswordList { get; set; } = new List<string>() {"marius", "thomas", "fabrizio", "nicola", "diego", "federico", "roberto"};
    
    
    private bool logged;
    
    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(CanInsertPassword))] 
    public partial string Name { get; set; } = "";

    public string StatusLogin => logged ? "Logout" : "Login";
    
    public bool CanInsertPassword => !string.IsNullOrWhiteSpace(Name);

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
        
        if (logged && Password != PasswordList[NameList.IndexOf(Name)])
        {
            ErrorMessage = "Password errata";
            logged = false;
            return;
        }
        
        Greeting = logged ? $"Benvenuto {Name}!" : $"Arrivederci {Name}!";
        
        OnPropertyChanged(nameof(StatusLogin));
    }
}