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
    Image photo;

    public ICommand TakePhotoCommand { get; }
    public ICommand SendRegisterCommand { get; }
    public ICommand MainPageCommand { get; }

    public RegisterViewModel()
    {
      TakePhotoCommand = new Command(TakePhotoExecute);
      MainPageCommand = new Command(Commands.MainPageExecute);
      SendRegisterCommand = new Command(SendRegisterExecute, SendRegisterCanExecute);
    }

    private bool SendRegisterCanExecute()
    {
      return photo != null;
    }

    private void SendRegisterExecute()
    {
      //TODO : Call backend
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

    public Image Photo
    {
      get { return photo; }
      set { photo = value; OnPropertyChanged(); }
    }

    public void TakePhotoExecute()
    {
      CrossMedia.Current.Initialize().Wait();
      if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
      {
        var task = CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
        {
          SaveToAlbum = true,
          Directory = "Sample",
          Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
        });
        task.Wait();

        var file = task.Result;

        if (file == null)
          return;
        
        photo = new Image() {
          Source = ImageSource.FromFile(file.Path)
        };
      }
    }


  }
}