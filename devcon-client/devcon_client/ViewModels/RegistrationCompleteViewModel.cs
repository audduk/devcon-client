using System.Windows.Input;

using Xamarin.Forms;

namespace devcon_client.ViewModels
{
  public class RegistrationCompleteViewModel : BaseViewModel
  {
    public RegistrationCompleteViewModel()
    {
      MainPageCommand = new Command(Commands.MainPageExecute);
    }

    public ICommand MainPageCommand { get; }
  }
}