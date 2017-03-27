using devcon_client.Helpers;
using devcon_client.Models;
using devcon_client.Views;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Net;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace devcon_client.ViewModels
{
  public class LoginViewModel : BaseViewModel
  {
    string message = string.Empty;
    string login = string.Empty;
    string photo = string.Empty;
    byte[] photoArray = null;

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

    private async void SendLoginExecute()
    {
      var client = new RestClient("http://10.30.22.73:5000");
      var request = new RestRequest("api/user/Login", Method.POST);
      request.AddParameter("login", Login); // adds to POST or URL querystring based on Method
      request.AddParameter("photo", JsonConvert.SerializeObject(PhotoArray)); // adds to POST or URL querystring based on Method

      // execute the request
      var response = await client.Execute(request);


      try
      {
        var model = new LoginModel()
        {
          Login = Login,
          Photo = PhotoArray
        };
        var content = JsonConvert.SerializeObject(model);
        var result = await RequestHelper.MakePostRequest("http://10.30.22.73:5000/api/user/Login", content, string.Empty, isJson: false);
        throw new NotImplementedException("Нет связи с сервером");
      }
      catch (Exception ex)
      {
        Message = ex.Message;
        return;
      }
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

    public byte[] PhotoArray
    {
      get { return photoArray; }
      set { photoArray = value; OnPropertyChanged(); }
    }
  }
}