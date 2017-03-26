using System.Windows.Input;

using Xamarin.Forms;

namespace devcon_client.ViewModels
{
  public class LoginCompleteViewModel : BaseViewModel
  {
    string login = string.Empty;
    string name = string.Empty;
    string phone = string.Empty;
    double confidence = 0;

    public double Confidence
    {
      get { return confidence; }
      set { confidence = value; OnPropertyChanged(); }
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

    public string ConfidenceMessage
    {
      get { return $"Мы уверены в том что это Вы на {Confidence}%"; }
    }

    public LoginCompleteViewModel()
    {
      MainPageCommand = new Command(Commands.MainPageExecute);
    }

    public ICommand MainPageCommand { get; }
  }
}