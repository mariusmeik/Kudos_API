using Core.Entities;

namespace Core.Contracts
{
    public interface IReasonRepository
    {
        public Task<ReasonEntity> GetById(int id);
    }
}
