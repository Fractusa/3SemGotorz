using Microsoft.Data.SqlClient;

namespace Gotorz.Services
{
    public class AuthStateService
    {
        public bool IsLoggedIn { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }

        //Event to allow other component to subscribe to, allowing them to refresh when login state changes
        public event Action? OnChange;

        //Method to login the user and set the login state
        public void Login(string email,string role)
        {
            IsLoggedIn = true;
            UserEmail = email;
            UserRole = role;
            NotifyStateChanged();

        }
        //Method to logout the user and clear the login state
        public void Logout()
        {
            IsLoggedIn = false;
            UserEmail = null;
            NotifyStateChanged();
        }

        //Method to raise the OnChange event, when loginState changes
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
