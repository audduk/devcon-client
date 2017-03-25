using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(devcon_client.MobileAppService.Startup))]

namespace devcon_client.MobileAppService
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureMobileApp(app);
    }
  }
}