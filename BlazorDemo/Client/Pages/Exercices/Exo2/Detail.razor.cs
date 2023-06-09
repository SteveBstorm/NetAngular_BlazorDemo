using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Client.Pages.Exercices.Exo2
{
    public partial class Detail
    {
        [Parameter]
        public Game CurrentGame { get; set; }
        
    }
}
