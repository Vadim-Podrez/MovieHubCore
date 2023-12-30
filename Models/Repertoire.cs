using System.ComponentModel.DataAnnotations;

namespace MovieHubCore.Models
{
    public class Repertoire
    {
        // Репертуар (Код сеансу, Дата, Час початку, Час, Ціна квитка) [10 записів]
        [Key]
        public int RepertoireId { get; set; }
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public decimal Price { get; set; }
        public Movie Movie { get; set; } // Відносина з фільмом
        public ICollection<Seat> Seats { get; set; }

        // public int MovieId { get; set; } // Додаткове поле
    }

}
