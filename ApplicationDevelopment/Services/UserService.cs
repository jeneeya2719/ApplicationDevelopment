

using ApplicationDevelopment.Abstraction;
using ApplicationDevelopment.Model;
using ApplicationDevelopment.Services.Interface;

namespace ApplicationDevelopment.Services
{
    public class UserService :UserBase, IUserService
    {
        private List<User> _users;

        // Default admin username and password for initial seeding.
        public const string SeedUsername = "admin";
        public const string SeedPassword = "password";
        public UserService()
        {
            _users = LoadUsers();

            // If no users are present, add a default admin user and save to the file.
            if (!_users.Any())
            {
                _users.Add(new User { Username = SeedUsername, Password = SeedPassword });
                SaveUsers(_users);
            }
        }
        public bool DeleteUser(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null) // If no user is found, return false.
                return false;

            // Remove the user from the list and save the updated list to the file.
            _users.Remove(user);
            SaveUsers(_users);
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public bool Login(User user)
        {
            // Validate input for null or empty values.
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return false; // Invalid input.
            }

            // Check if the username and password match any user in the list.
            return _users.Any(u => u.Username == user.Username && u.Password == user.Password);
        }

        public bool Register(User user)
        {
            if (_users.Any(u => u.Username == user.Username))
                return false; // Registration failed: user already exists.

            // Add the new user to the list and save the updated list to the file.
            _users.Add(new User { Username = user.Username, Password = user.Password });
            SaveUsers(_users);
            return true;
        }
    }
}
