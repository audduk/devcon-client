using devcon_client.Views;
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

    public static void AskRegisterCommand()
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
  }
}
