using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Models;
using MishMashWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using Type = MishMashWebApp.Models.Enums.Type;

namespace MishMashWebApp.Controllers.Channels
{
    public class ChannelsController : BaseController
    {
        public IHttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Create(ChannelViewModel model)
        {
            var tags = new List<Tag>();
            var tagNames = model.Tags.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var tagName in tagNames)
            {
                tags.Add(new Tag { Name = tagName });
            }

            var channel = new Channel
            {
                Name = model.Name,
                Description = model.Description,
                Tags = tags,
                Type = Enum.Parse<Type>(model.Type)
            };
            this.ApplicationDbContext.Channels.Add(channel);
            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/");
        }

        public IHttpResponse Follow(string id)
        {
            var user = this.ApplicationDbContext
                .Users
                .FirstOrDefault(x => x.Username == this.User.Username);

            var channel = this.ApplicationDbContext
                .Channels
                .FirstOrDefault(x => x.Id == id);
            //Many-to-many relation, take user, take channel, save 2 ids so for every user there is channel id even if its the same user
            var userChannel = new UserChannel
            {
                Channel = channel,
                User = user
            };

            user.FollowedChannels.Add(userChannel);
            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/");
        }

        public IHttpResponse Details(string id)
        {
            var channel = this.ApplicationDbContext.Channels.Include(x => x.Tags).FirstOrDefault(x => x.Id == id);
            var tags = string.Empty;
            foreach (var channelTag in channel.Tags)
            {
                tags += channelTag.Name;
            }

            var followers = this.ApplicationDbContext.UserChannels.Count(x => x.ChannelId == channel.Id);
            var viewModel = new ChannelViewModel
            {
                Name = channel.Name,
                Type = channel.Type.ToString(),
                Description = channel.Description,
                Followers = followers,
                Tags = tags
            };
            return this.View(viewModel);
        }

        public IHttpResponse Followed()
        {
            var currentUser = this
                .ApplicationDbContext
                .Users
                .Include(x => x.FollowedChannels)
                .ThenInclude(x => x.Channel)
                .ThenInclude(x => x.Tags)
                .FirstOrDefault(x => x.Username == this.User.Username);

            var channels = currentUser.FollowedChannels.Select(x => x.Channel).ToList();
            var viewModel = new ChannelViewModel
            {
                FollowedChannels = channels
            };
            for (int i = 0; i < viewModel.FollowedChannels.Count; i++)
            {
                Console.WriteLine(viewModel.FollowedChannels.ToList()[i].Id);
            }

            return this.View(viewModel);
        }

        public IHttpResponse Unfollow(string id)
        {
            var currentUser = this
                .ApplicationDbContext
                .Users
                .Include(x => x.FollowedChannels)
                .ThenInclude(x => x.Channel)
                .ThenInclude(x => x.Tags)
                .FirstOrDefault(x => x.Username == this.User.Username);
            var toBeRemoved = currentUser.FollowedChannels.FirstOrDefault(x => x.ChannelId == id);

            currentUser.FollowedChannels.Remove(toBeRemoved);
            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/channels/followed");
        }
    }
}
