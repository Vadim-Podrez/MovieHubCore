namespace MovieHubCore.Models
{
    public class Position
    {
        // Посади(Код посади, Найменування посади, Оклад, Обов'язки, Вимоги)
        // [5 записів].

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public decimal Salary { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }
    }

}
