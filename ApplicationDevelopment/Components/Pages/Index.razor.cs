using ApplicationDevelopment.Model;
using Microsoft.AspNetCore.Components;

namespace ApplicationDevelopment.Components.Pages
{
    public partial class Index : ComponentBase
    {

        [CascadingParameter]
        private GlobalState _globalState { get; set; }

        protected override void OnInitialized()
        {

            Nav.NavigateTo("/login");

        }
    }
}