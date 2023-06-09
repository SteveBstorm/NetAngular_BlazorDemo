namespace BlazorDemo.Client.Pages.Exercices.Exo2
{
    public partial class Exo2
    {
        public List<Game> Games { get; set; }
        public Game SelectedGame { get; set; }

        public Exo2()
        {
            Games = new List<Game>();
            Games.Add(new Game
            {
                Id = Games.Count + 1,
                Title = "Diablo 4",
                Genre = "Hack'n slash",
                ReleaseYear = 2023,
                Note = 2
            });
        }

        public void AddGame(GameForm form)
        {
            Games.Add(new Game
            {
                Id = Games.Count + 1,
                Title = form.Title,
                Genre = form.Genre,
                ReleaseYear = form.ReleaseYear,
                Note = form.Note
            });
        }

        public void SelectGame(int id)
        {
            SelectedGame = Games.FirstOrDefault(x => x.Id == id);
        }
    }
}
