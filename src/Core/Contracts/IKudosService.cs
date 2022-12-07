using Core.Entities;

namespace Core.Contracts
{
    public interface IKudosService
    {
        public Task<int> Create(KudosEntity kudos);
        public Task<List<KudosEntity>> Get(KudosQueryParameters parameters);
        public Task<KudosEntity> Exchange(int id);
    }
}
