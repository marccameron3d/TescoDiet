using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TescoDiets.Startup))]
namespace TescoDiets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
