using Core.Contracts;
using Core.Entities;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ReportService : IReportService
    {
        private IKudosRepository _kudosRepository;
        private IEmployeeRepository _employeRepository;

        public ReportService(IKudosRepository kudosRepository, IEmployeeRepository employeRepository)
        {
            _kudosRepository = kudosRepository;
            _employeRepository = employeRepository;
        }
        public async Task<ReportEntity> GenerateReport(DateTime date)
        {
            ReportEntity report = new();
            var kudos =await _kudosRepository.Get();

            if (kudos == null)
            {
                throw new KudosNotFoundException();
            }

            kudos = kudos.Where(x => x.CreatedDate.Year == date.Year && x.CreatedDate.Month == date.Month).ToList();

            var kudosAmmount = kudos.Count();

            if (kudosAmmount == 0)
            {
                throw new KudosNotFoundException();
            }

            report.KudosReceived = kudosAmmount;

            int bestGiverId=kudos.GroupBy(q => q.GiverId)
                                    .OrderByDescending(gp => gp.Count())
                                    .First()
                                    .Select(g => g.GiverId).ToList()[0];

            int bestReceiverId = kudos.GroupBy(q => q.GiverId)
                                    .OrderByDescending(gp => gp.Count())
                                    .First()
                                    .Select(g => g.GiverId).ToList()[0];

            report.BestGiver= await _employeRepository.GetById(bestGiverId);
            report.BestRecever = await _employeRepository.GetById(bestReceiverId);

            return report;
        }

    }

}
