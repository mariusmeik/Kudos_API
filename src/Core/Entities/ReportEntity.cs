namespace Core.Entities
{
    public class ReportEntity
    {
        public EmployeeEntity? BestGiver { get; set; }
        public EmployeeEntity? BestRecever { get; set; }
        public int KudosReceived { get; set; }
    }
}
