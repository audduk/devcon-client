using devcon_client.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace devcon_client.ViewModels
{
  public class LoginViewModel : BaseViewModel
  {
    string message = string.Empty;
    string login = string.Empty;
    string photo = string.Empty;

    public Command TakePhotoCommand { get; }
    public Command SendLoginCommand { get; }
    public Command MainPageCommand { get; }

    public LoginViewModel()
    {
      MainPageCommand = new Command(Commands.MainPageExecute);
      SendLoginCommand = new Command(SendLoginExecute, SendLoginCanExecute);
      this.PropertyChanged += RegisterViewModel_PropertyChanged;
    }

    private void RegisterViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      SendLoginCommand.ChangeCanExecute();
    }

    private bool SendLoginCanExecute()
    {
      return !string.IsNullOrWhiteSpace(photo)
        && !string.IsNullOrWhiteSpace(login) && login.Trim().Length>=2;
    }

    private void SendLoginExecute()
    {
      var loginCompleteViewModel = new LoginCompleteViewModel();
      loginCompleteViewModel.Login = Login;
      loginCompleteViewModel.Name = "Иванов Иван Иванович";
      loginCompleteViewModel.Confidence = 12.3;
      var loginCompletePage = new NavigationPage(new LoginCompletePage())
      {
        BarBackgroundColor = (Color)App.Current.Resources["Primary"],
        BarTextColor = Color.White,
        BindingContext = loginCompleteViewModel
      };
      App.Current.MainPage = loginCompletePage;
      return;
      try
      {
        throw new NotImplementedException("Нет связи с сервером");
      }
      catch (Exception ex)
      {
        Message = ex.Message;        
      }      
    }

    public string Message
    {
      get { return message; }
      set { message = value; OnPropertyChanged(); }
    }

    public string Login
    {
      get { return login; }
      set { login = value; OnPropertyChanged(); }
    }

    public string Photo
    {
      get { return photo; }
      set { photo = value; OnPropertyChanged(); }
    }
  }
}