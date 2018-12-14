using System;
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
            var channel = new Channel
            {
                Name = model.Name,
                Description = model.Description,
                Tags = model.Tags,
                Type = Enum.Parse<Type>(model.Type)
            };
            this.ApplicationDbContext.Channels.Add(channel);
            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/");
        }
    }
}
