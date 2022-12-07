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
    public class ReasonRepository : IReasonRepository
    {
        private readonly NpgsqlConnection _connection;

        public ReasonRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<ReasonEntity> GetById(int id)
        {

            var query = @"SELECT id, reason
            FROM public.reason
            WHERE id=@Id;";
            return await _connection.QueryFirstOrDefaultAsync<ReasonEntity>(query, new
            {
                Id = id
            });
        }
    }
}