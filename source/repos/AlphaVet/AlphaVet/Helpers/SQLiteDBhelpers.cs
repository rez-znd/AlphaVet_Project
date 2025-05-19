using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using AlphaVet.Model;

namespace AlphaVet.Helpers
{
    public class SQLiteDBhelpers
    {
        readonly SQLiteAsyncConnection connection;
        public SQLiteDBhelpers(string path)
        {
            connection = new SQLiteAsyncConnection(path);

            connection.CreateTableAsync<especie>().Wait();
        }

        public Task<int> Insert(especie p)
        {
            return connection.InsertAsync(p);
        }
        public Task<List<especie>> Update(especie p)
        {
            string sql = "UPDATE Especie SET espid=?, espnome=? WHERE espid=?";
            return connection.QueryAsync<especie>(sql, p.espid, p.espnome, p.espid);
        }
        public Task<List<especie>> Delete(int espid)
        {
            string sql = "DELETE FROM Especie Where espid=?";
            return connection.QueryAsync<especie>(sql, espid);
        }
        public Task<List<especie>> GetAll()
        {
            return connection.Table<especie>().ToListAsync();
        }
        public Task<List<especie>> Search(string p)
        {
            string sql = "SELECT * FROM especie WHERE espnome LIKE ?";
            return connection.QueryAsync<especie>(sql, $"%{p}%");
        }
    }
}
