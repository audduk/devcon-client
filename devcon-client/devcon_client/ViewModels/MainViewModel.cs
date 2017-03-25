using System.Threading.Tasks;
using System.Windows.Input;

using devcon_client.Models;
using devcon_client.Helpers;
using devcon_client.Services;

using Xamarin.Forms;

namespace devcon_client.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
    public MainViewModel()
    {
      AskRegisterCommand = new Command(Commands.AskRegisterCommand);
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