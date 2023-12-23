namespace MovieHubCore.Models
{
    public class Genre
    {
        // Жанри (Код жанру, Найменування, Опис) [5 записів].
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
    }

}
