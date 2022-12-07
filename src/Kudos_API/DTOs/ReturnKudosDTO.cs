namespace KudosAPI.DTOs
{
    public class ReturnKudosDTO
    {
        public int ReceiverId { get; set; }
        public int GiverId { get; set; }
        public int ReasonId { get; set; }
        public string? ThanksMessage { get; set; }
        public bool IsClaimed { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
