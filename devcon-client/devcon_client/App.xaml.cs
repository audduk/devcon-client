using System.Collections.Generic;

using devcon_client.Helpers;
using devcon_client.Services;
using devcon_client.Views;
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

      if (AzureNeedsSetup)
        DependencyService.Register<MockDataStore>();
      else
        DependencyService.Register<AzureDataStore>();

      SetMainPage();
    }

    public static void SetMainPage()
    {
      Commands.MainPageExecute();
    }

    public static void GoToMainPage()
    {
      Current.MainPage = new TabbedPage
      {
        Children =
        {
          new NavigationPage(new ItemsPage())
          {
            Title = "Browse",
            Icon = Device.OnPlatform("tab_feed.png",null,null)
          },
          new NavigationPage(new AboutPage())
          {
            Title = "About",
            Icon = Device.OnPlatform("tab_about.png",null,null)
          },
        }
      };
    }
  }
}
