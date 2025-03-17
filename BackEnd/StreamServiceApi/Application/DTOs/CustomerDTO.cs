namespace Application.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string? IdenticacionCode { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
