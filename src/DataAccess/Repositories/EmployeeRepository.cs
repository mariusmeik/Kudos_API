using Core.Contracts;
using Core.Entities;
using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NpgsqlConnection _connection;

        public EmployeeRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }


        public async Task<int> Create(EmployeeEntity employe)
        {
            var query = @"INSERT INTO public.employe
            (first_name, last_name)
            VALUES(@FirstName, @LastName) 
            Returning *;";

            var result = await _connection.QueryFirstAsync(query, new
            {
                FirstName = employe.FirstName,
                LastName = employe.LastName
            });

            return result.id;
        }
        public async Task<List<EmployeeEntity>> Get()
        {

            var query = @"SELECT id, first_name, last_name
            FROM public.employe;";

            var employees = await _connection.QueryAsync<EmployeeEntity>(query);

            return employees.ToList();
        }

        public async Task<EmployeeEntity> GetById(int id)
        {
            var query = @"SELECT id, first_name, last_name
            FROM public.employe 
            WHERE id=@Id;";

            return await _connection.QueryFirstOrDefaultAsync<EmployeeEntity>(query, new
            {
                Id = id
            });

        }

    }
}
