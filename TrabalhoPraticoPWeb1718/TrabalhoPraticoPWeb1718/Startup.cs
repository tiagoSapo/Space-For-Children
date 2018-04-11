using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrabalhoPraticoPWeb1718.Startup))]
namespace TrabalhoPraticoPWeb1718
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
