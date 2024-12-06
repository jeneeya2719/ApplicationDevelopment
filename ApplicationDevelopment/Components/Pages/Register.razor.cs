using ApplicationDevelopment.Model;
using Microsoft.AspNetCore.Components;

namespace ApplicationDevelopment.Components.Pages
{
    public partial class Register: ComponentBase
    {
        private string? Message;

        private User Users { get; set; } = new User();

        private async void RegisterUser()
        {
            if (UserService.Register(Users))
            {
                Message = "User registered successfully!";
                Nav.NavigateTo("/login");
            }
            else
            {
                Message = "Username already exists.";
            }
        }

    }
}