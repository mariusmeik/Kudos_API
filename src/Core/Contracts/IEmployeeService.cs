using Core.Entities;

namespace Core.Contracts
{
    public interface IEmployeeService
    {
        public Task<int> Create(EmployeeEntity employe);
        public Task<List<EmployeeEntity>> Get();
    }
}
