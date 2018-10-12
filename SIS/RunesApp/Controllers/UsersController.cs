﻿using System;
using System.Linq;
using RunesApp.Models;
using RunesApp.Services;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace RunesApp.Controllers
{
    public class UsersController : BaseController
    {
        private const string InvalidUsernameMessage = "<h1>Please provide valid username with length of 4 or more characters!</h1>";
        private const string UsernameAlreadyExists = "<h1>That username is already in use, please pick different one!</h1>";
        private const string PasswordLengthRequirement = "<h1>Please provide password longer than 6 digits!</h1>";
        private const string PassowordsDoesntMatch = "<h1>Passwords do not match!</h1>";
        private const string InvalidUsernameOrPassword = "Invalid Username or password.";

        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View();
        }

        public IHttpResponse PostLogin(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();

            var hashedPassword = new HashService().Hash(password);

            var user = this.Db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);

            if (user == null)
            {
                return new RedirectResult("/login");
            }
            var response = new RedirectResult("/home/index");
            this.SignInUser(username, response, request);
            //to logged in html
            return response;

        }
        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View();
        }
        public IHttpResponse PostRegister(IHttpRequest request)
        {
            //// return new HtmlResult("REGISTERED", HttpResponseStatusCode.Ok);

            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
            {
                return this.BadRequestError(InvalidUsernameMessage);
            }

            if (this.Db.Users.Any(x => x.Username == userName))
            {
                return BadRequestError(UsernameAlreadyExists);
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return this.BadRequestError(PasswordLengthRequirement);
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError(PassowordsDoesntMatch);
            }
            ////Hash password
            var hashedPassword = this.HashService.Hash(password);
            var user = new User
            {
                Username = userName,
                Password = hashedPassword,
            };
            try
            {
                this.Db.Users.Add(user);
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                ////TODO: Log error
                return this.ServerError(e.Message);
            }

            var response = new RedirectResult("/");
            this.SignInUser(userName, response, request);
            return response;
        }
    }
}