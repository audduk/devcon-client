using devcon_client.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace devcon_client
{
  public static class Commands
  {
    public static void MainPageExecute()
    {
      App.Current.MainPage = new NavigationPage(new MainPage())
      {
        BarBackgroundColor = (Color)App.Current.Resources["Primary"],
        BarTextColor = Color.White
      };
    }

    public static void AskRegisterExecute()
    {
      App.Current.MainPage = new NavigationPage(new RegisterPage())
      {
        BarBackgroundColor = (Color)App.Current.Resources["Primary"],
        BarTextColor = Color.White
      };
    }

    public static void AskLoginExecute()
    {
      App.Current.MainPage = new NavigationPage(new LoginPage())
      {
        BarBackgroundColor = (Color)App.Current.Resources["Primary"],
        BarTextColor = Color.White
      };
    }

    public static void RegistrationCompleteExecute()
    {
      App.Current.MainPage = new NavigationPage(new RegistrationCompletePage())
      {
        BarBackgroundColor = (Color)App.Current.Resources["Primary"],
        BarTextColor = Color.White
      };
    }
  }
}
