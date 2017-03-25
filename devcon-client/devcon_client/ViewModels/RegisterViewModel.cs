using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace devcon_client.ViewModels
{
  public class RegisterViewModel : BaseViewModel
  {
    string message = string.Empty;
    string login = string.Empty;
    string name = string.Empty;
    string phone = string.Empty;
    string photo = string.Empty;

    public Command TakePhotoCommand { get; }
    public Command SendRegisterCommand { get; }
    public Command MainPageCommand { get; }

    public RegisterViewModel()
    {
      MainPageCommand = new Command(Commands.MainPageExecute);
      SendRegisterCommand = new Command(SendRegisterExecute, SendRegisterCanExecute);
      this.PropertyChanged += RegisterViewModel_PropertyChanged;
    }

    private void RegisterViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      SendRegisterCommand.ChangeCanExecute();
    }

    private bool SendRegisterCanExecute()
    {
      return !string.IsNullOrWhiteSpace(photo)
        && !string.IsNullOrWhiteSpace(login) && login.Trim().Length>=2
        && !string.IsNullOrWhiteSpace(name) && name.Trim().Length>2        ;
    }

    private void SendRegisterExecute()
    {
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


    public string Name
    {
      get { return name; }
      set { name = value; OnPropertyChanged(); }
    }

    public string Phone
    {
      get { return phone; }
      set { phone = value; OnPropertyChanged(); }
    }

    public string Photo
    {
      get { return photo; }
      set { photo = value; OnPropertyChanged(); }
    }

     
  }
}