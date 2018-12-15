using System.Collections.Generic;
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
            var currentUser = this.ApplicationDbContext.Users.FirstOrDefault(x => x.Username == this.User.Username);

            var yourChannels = this.ApplicationDbContext
                .UserChannels.Include(x => x.Channel).Include(x => x.Channel.Tags)
                .Where(x => x.UserId == currentUser.Id).ToList();
            var seeOther = new List<Channel>();
            var allChannels = this.ApplicationDbContext.Channels.ToList();

            foreach (var userChannel in allChannels)
            {
                if (!this.ApplicationDbContext.UserChannels.Any(x => x.Channel.Id == userChannel.Id))
                {
                    seeOther.Add(userChannel);
                }
            }
            //take all my channels, take their tags, check if allTags equals any of my tags

            var suggested = new List<Channel>();
            var myTags = new List<Tag>();
            foreach (var yourChannel in yourChannels)
            {
                foreach (var tag in yourChannel.Channel.Tags)
                {
                    myTags.Add(tag);
                }
            }

            var allTags = this.ApplicationDbContext.Tags.ToList();
            foreach (var tag in allTags)
            {
                if (myTags.Contains(tag))
                {
                    suggested = this.ApplicationDbContext.Channels
                        .Where(x => x.Id == tag.ChannelId).ToList();
                }
            }

            var viewModel = new ChannelViewModel
            {
                YourChannels = yourChannels,
                SeeOther = seeOther,
                SuggestedChannels = suggested
            };
            return this.View("/Home/IndexLoggedIn", viewModel);
        }
    }
}