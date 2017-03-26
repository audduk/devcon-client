
using devcon_client.ViewModels;
using Plugin.Media;
using Xamarin.Forms;

namespace devcon_client.Views
{
  public partial class RegisterPage : ContentPage
  {
    public RegisterPage()
    {
      InitializeComponent();
      btnTakePhoto.Clicked += async (sender, args) =>
      {
        await CrossMedia.Current.Initialize();

        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        {
          await DisplayAlert("No Camera", ":( No camera available.", "OK");
          return;
        }

        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        {
          Directory = "Sample",          
          Name = "test.jpg"
        });

        if (file == null)
          return;
        /*
        var stream = file.GetStream();
        
        await DisplayAlert("File Size", $"{stream.Length}", "OK");
        stream.Dispose();

        await DisplayAlert("File Location", file.Path, "OK");
        
         * 
         */
         
        /*
                var imageSource = ImageSource.FromStream(() => {
                  var stream = file.GetStream();
                  file.Dispose();
                  return stream;
                });
        */
        ((RegisterViewModel)this.BindingContext).Photo = file.Path;
        //or:
        //image.Source = ImageSource.FromFile(file.Path);
        //image.Dispose();
      };
    }
  }
}
