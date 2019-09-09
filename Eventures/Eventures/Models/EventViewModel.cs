namespace Eventures.Models
{
    public class EventViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public int TotalTickets { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
