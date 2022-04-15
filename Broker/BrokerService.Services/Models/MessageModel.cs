namespace BrokerService.Services.Models
{
    public class MessageModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }

    public class EmailMessageModel
    {
        public string Email { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }
}
