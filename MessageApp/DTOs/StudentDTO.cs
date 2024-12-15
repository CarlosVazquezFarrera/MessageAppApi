namespace MessageApp.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }

        public string Clave { get; set; } = null!;

        public string Nombre { get; set; } = null!;
    }
}
