namespace MessageApp.DTOs
{
    public class MessageDTO
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public DateTime? Createdat { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public Guid Studentid { get; set; }


    }
}
