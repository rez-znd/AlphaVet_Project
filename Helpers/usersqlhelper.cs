using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using AlphaVet.Model;

namespace AlphaVet.Helpers
{
    public class usersqlhelper
    {
        readonly SQLiteAsyncConnection connection;
        public usersqlhelper(string path)
        {
            connection = new SQLiteAsyncConnection(path);

            connection.CreateTableAsync<user>().Wait();
        }

        public Task<int> Insert(user p)
        {
            return connection.InsertAsync(p);
        }
        public Task<List<user>> GetAll()
        {
            return connection.Table<user>().ToListAsync();
        }
        public Task<List<user>> Search(string p)
        {
            string sql = "SELECT * FROM user WHERE username LIKE ?";
            return connection.QueryAsync<user>(sql, $"%{p}%");
        }
    }
}
