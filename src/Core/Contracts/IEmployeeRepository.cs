using Core.Entities;

namespace Core.Contracts
{
    public interface IEmployeeRepository
    {
        public Task<int> Create(EmployeeEntity employe);
        public Task<List<EmployeeEntity>> Get();
        public Task<EmployeeEntity> GetById(int id);
    }
}
