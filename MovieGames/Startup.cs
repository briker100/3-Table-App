using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieGames.Startup))]
namespace MovieGames
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
