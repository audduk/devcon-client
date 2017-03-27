
using devcon_client.ViewModels;
using Plugin.Media;
using Xamarin.Forms;

namespace devcon_client.Views
{
  public partial class LoginPage : ContentPage
  {
    public LoginPage()
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
          Name = "test.jpg",
          DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
          CompressionQuality = 50,
          PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
          AllowCropping = true          
        });

        if (file == null)
          return;
        
        var stream = file.GetStream();
        
        await DisplayAlert("File Size", $"{stream.Length}", "OK");
        stream.Dispose();

        await DisplayAlert("File Location", file.Path, "OK");
        
        
        /*
               var imageSource = ImageSource.FromStream(() => {
                 var stream = file.GetStream();
                 file.Dispose();
                 return stream;
               });
       */
        var vm = ((LoginViewModel)this.BindingContext);
        vm.Photo = file.Path;
        var stream2 = file.GetStream();
        var buffer = new byte[stream2.Length];
        stream2.Read(buffer, 0, (int)stream2.Length);
        vm.PhotoArray = buffer;
        file.Dispose();
        //or:
        //image.Source = ImageSource.FromFile(file.Path);
        //image.Dispose();
      };
    }
  }
}
