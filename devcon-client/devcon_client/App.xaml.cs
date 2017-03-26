using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace devcon_client
{
  public partial class App : Application
  {
    //MUST use HTTPS, neglecting to do so will result in runtime errors on iOS
    public static bool AzureNeedsSetup => AzureMobileAppUrl == "https://CONFIGURE-THIS-URL.azurewebsites.net";
    public static string AzureMobileAppUrl = "https://devconclient20170325012615.azurewebsites.net";
    public static IDictionary<string, string> LoginParameters => null;

    public App()
    {
      InitializeComponent();
      SetMainPage();
    }

    public static void SetMainPage()
    {
      Commands.MainPageExecute();
    }
  }
}
