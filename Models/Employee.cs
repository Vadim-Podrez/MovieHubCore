namespace MovieHubCore.Models
{


    public class Employee
    {
        // Працівники (Код співробітника, ПІБ, Вік, Пол, Адреса, Телефон, Паспортні дані, Код посади)
        // [10 записів].
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportData { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }

    }
}
