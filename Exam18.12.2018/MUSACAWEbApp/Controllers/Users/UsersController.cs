﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using MUSACAWEbApp.Models;
using MUSACAWEbApp.Models.Enums;
using MUSACAWEbApp.ViewModels;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MUSACAWEbApp.Controllers.Users
{
    public class UsersController : BaseController
    {
        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(UserViewModel model)
        {
            if (this.ApplicationDbContext.Users.Any(x => x.Username == model.Username))
            {
                return this.BadRequestError($"Username: {model.Username} already exist!");
            }
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrWhiteSpace(model.Username))
            {
                return this.BadRequestErrorWithView("Username can't be null!");
            }

            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrWhiteSpace(model.Password))
            {
                return this.BadRequestErrorWithView("Password can't be null!");
            }

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrWhiteSpace(model.Email))
            {
                return this.BadRequestErrorWithView("Email can't be null!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.BadRequestError("Passwords should match!");
            }

            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Role = Role.User
            };
            //UNCOMMENT THE SECTION BELOW If u wanna test admin faster :))
            //if (!this.ApplicationDbContext.Users.Any())
            //{
            //    user.Role = Role.Admin;
            //}

            this.ApplicationDbContext.Users.Add(user);
            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("/Users/Login");
        }

        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(UserViewModel model)
        {
            var user = this.ApplicationDbContext.Users.FirstOrDefault(x =>
                x.Username == model.Username.Trim() &&
                x.Password == model.Password);

            if (user == null)
            {
                return this.BadRequestErrorWithView("Invalid username or password.");
            }

            var mvcUser = new MvcUserInfo
            {
                Username = user.Username,
                Role = user.Role.ToString(),
            };
            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-exam", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-exam"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-exam");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        public IHttpResponse Profile()
        {
            var user = this.ApplicationDbContext.Users.FirstOrDefault(x => x.Username == this.User.Username);
            var receipts = this.ApplicationDbContext.Receipts
                .Include(x => x.Cashier).Include(x => x.Orders).ThenInclude(x => x.Product).Where(x => x.Cashier.Username == user.Username).ToList();

            var viewModel = new ReceiptViewModel
            {
                Receipts = receipts,

            };
            return this.View(viewModel);
        }
    }
}