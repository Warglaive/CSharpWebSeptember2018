namespace CakesWebApp.Services
{
    public interface IUserCookieService
    {
        string GetUserCookie(string username);
        string GetUserData(string cookieContent);
    }
}