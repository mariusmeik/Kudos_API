using Core.Entities;

namespace Core.Contracts
{
    public interface IReportService
    {
        public Task<ReportEntity> GenerateReport(DateTime date);
    }
}
