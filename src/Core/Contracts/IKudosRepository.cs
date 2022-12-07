using Core.Entities;

namespace Core.Contracts
{
    public interface IKudosRepository
    {
        public Task<int> Create(KudosEntity kudos);
        public Task<List<KudosEntity>> Get();
        public Task<KudosEntity> GetById(int id);
        public Task<KudosEntity> Exchange(int id);
    }
}
