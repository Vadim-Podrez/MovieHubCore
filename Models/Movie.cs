namespace MovieHubCore.Models
{
    public class Movie
    {
        // Фільми(Код фільму, Найменування, Код жанру, Тривалість, Фірма виробник, Країна виробник, Актѐри, Вікові обмеження, Опис)
        // [10 записів].
        
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int Duration { get; set; }
        public string ProductionCompany { get; set; }
        public string ProductionCountry { get; set; }
        public string Actors { get; set; }
        public string AgeRestrictions { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
    }

}
