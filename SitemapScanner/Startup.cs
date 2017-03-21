using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SitemapScanner.Startup))]
namespace SitemapScanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
