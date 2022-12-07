using Core.Contracts;
using Core.Entities;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class KudosRepository : IKudosRepository
    {
        private readonly NpgsqlConnection _connection;

        public KudosRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> Create(KudosEntity kudos)
        {
            var query = @"INSERT INTO public.kudos
            (receiver_id, giver_id, reason_id, thanks_message, is_claimed, created_date)
            VALUES(@ReceiverId, @GiverId, @ReasonId, @ThanksMessage, false, @CreatedDate)
            Returning *;";

            var result = await _connection.QueryFirstAsync(query, new
            {
                ReceiverId = kudos.ReceiverId,
                GiverId = kudos.GiverId,
                ReasonId = kudos.ReasonId,
                ThanksMessage = kudos.ThanksMessage,
                CreatedDate = DateTime.Now
            });

            return result.id;
        }

        public async Task<List<KudosEntity>> Get()
        {

            var query = @"SELECT id, receiver_id, giver_id, reason_id, thanks_message, is_claimed, created_date
            FROM public.kudos;";

            var kudos = await _connection.QueryAsync<KudosEntity>(query);

            return kudos.ToList();
        }
        public async Task<KudosEntity> GetById(int id)
        {

            var query = @"SELECT id, receiver_id, giver_id, reason_id, thanks_message, is_claimed, created_date
            FROM public.kudos
            WHERE id=@Id;";

            var kudos = await _connection.QueryFirstOrDefaultAsync<KudosEntity>(query, new
            {
                Id = id
            });

            return kudos;
        }
        public async Task<KudosEntity> Exchange(int id)
        {

            var query = @"UPDATE public.kudos
            SET is_claimed=true
            WHERE id=@Id
            Returning *;";

            var kudos = await _connection.QueryFirstAsync<KudosEntity>(query, new
            {
                Id = id
            });

            return kudos;
        }

    }
}
