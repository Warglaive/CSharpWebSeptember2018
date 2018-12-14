using System.Linq;
using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Models;
using MishMashWebApp.ViewModels;
using SIS.HTTP.Responses;

namespace MishMashWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (!this.User.IsLoggedIn)
            {
                return this.View();
            }
            //return channels
            //take current User, take all his followed channels
            //when user click on follow -> channelId will be added in followingIds
            var seeOther = this.ApplicationDbContext.Channels.Include(x => x.User).ToList();
            // var yourChannels = this.ApplicationDbContext.Channels.ToList();

            var viewModel = new ChannelViewModel
            {
                SeeOther = seeOther,
            };
            //foreach (var channel in viewModel.SeeOther)
            //{
            //    channel.Id
            //}
            return this.View("/Home/IndexLoggedIn", viewModel);
        }
    }
}