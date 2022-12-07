namespace Core.Entities
{
    public class KudosEntity
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public int GiverId { get; set; }
        public int ReasonId { get; set; }
        public string? ThanksMessage { get; set; }
        public bool IsClaimed { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
