using System.Windows.Input;

using Xamarin.Forms;

namespace devcon_client.ViewModels
{
  public class RegistrationCompleteViewModel : BaseViewModel
  {
    public RegistrationCompleteViewModel()
    {
      AskRegisterCommand = new Command(Commands.AskRegisterExecute);
      AskLoginCommand = new Command(Commands.AskLoginExecute);
    }

    string message = string.Empty;
    public string Message
    {
      get { return message; }
      set { message = value; OnPropertyChanged(); }
    }

    public ICommand AskRegisterCommand { get; }
    public ICommand AskLoginCommand { get; }

  }
}