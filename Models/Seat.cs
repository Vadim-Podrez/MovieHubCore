namespace MovieHubCore.Models
{
    public class Seat
    {
        // Місця (Код сеансу, Номер місця, Зайнятість, Код співробітника)
        // [15 записів]. 
        public int SeatId { get; set; }
        public int SessionId { get; set; }
        public int SeatNumber { get; set; }
        public bool IsOccupied { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Repertoire Session { get; set; } // Відносина з сеансом
    }

}
