using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace BlazorDemo.Client.Pages.Exercices.Exo2
{
    public partial class Exo2
    {
        public List<Game> Games { get; set; }
        public int SelectedGame { get; set; }

        [Inject]
        public HttpClient client { get; set; }
        public HubConnection gameHub { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Games = await client.GetFromJsonAsync<List<Game>>("game");

            gameHub = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7275/gamehub")).Build();

            gameHub.On("newGame", async () =>
            {
                Console.WriteLine("tu passes ici au moins ?");
                Games = await client.GetFromJsonAsync<List<Game>>("game");
                StateHasChanged();
            });
            
            await gameHub.StartAsync();
            //await gameHub.SendAsync("NotifyNewGame");
        }

        public Exo2()
        {
            Games = new List<Game>();
            //Games.Add(new Game
            //{
            //    Id = Games.Count + 1,
            //    Title = "Diablo 4",
            //    Genre = "Hack'n slash",
            //    ReleaseYear = 2023,
            //    Note = 2
            //});
        }

        //A modifier
        public async Task AddGame(GameForm form)
        {
            Game myGame = new Game
            {
                //Id = Games.Count + 1,
                Title = form.Title,
                Genre = form.Genre,
                ReleaseYear = form.ReleaseYear,
                Note = form.Note
            };

            Task t = client.PostAsJsonAsync<Game>("game", myGame);
            //if(t.IsCompleted)
            //    Games = await client.GetFromJsonAsync<List<Game>>("game");
        }

        public void SelectGame(int id)
        {
            SelectedGame = id;
        }
    }
}
