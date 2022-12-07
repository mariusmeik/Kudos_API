using Core.Contracts;
using Core.Entities;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeRepository;

        public EmployeeService(IEmployeeRepository employeRepository)
        {
            _employeRepository = employeRepository;
        }

        public async Task<int> Create(EmployeeEntity employe)
        {
            return await _employeRepository.Create(employe);
        }
        public async Task<List<EmployeeEntity>> Get()
        {
            return await _employeRepository.Get();
        }
    }
}