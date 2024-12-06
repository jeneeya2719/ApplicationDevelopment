using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationDevelopment.Model;
namespace ApplicationDevelopment.Services.Interface;

public interface IUserService
{
    // Authenticates a user based on their username and password.
    // Returns true if the credentials are valid, otherwise false.
    bool Login(User user);

    // Registers a new user with the given details.
    // Returns true if the registration is successful, or false if the username already exists.
    bool Register(User user);

    // Deletes a user identified by their username.
    // Returns true if the user is successfully deleted, or false if the user does not exist.
    bool DeleteUser(string username);

    // Retrieves a list of all registered users.
    // Returns the complete collection of User objects.
    List<User> GetAllUsers();
}
