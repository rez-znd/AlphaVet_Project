using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using AlphaVet.Model;

namespace AlphaVet.Helpers;

public class animalsqlhelper

{
    readonly SQLiteAsyncConnection connection;
    public animalsqlhelper(string path)
    {
        connection = new SQLiteAsyncConnection(path);

        connection.CreateTableAsync<animal>().Wait();
    }

    public Task<int> Insert(animal p)
    {
        return connection.InsertAsync(p);
    }
    public Task<List<animal>> Update(animal p)
    {
        string sql = "UPDATE Animal SET aniid=?, aninome=?, aniapelido=?, anidatanasc=?, aniobservacoes=?, espid=?, cliid=? WHERE aniid=?";
        return connection.QueryAsync<animal>(sql, p.aniid, p.aninome, p.aniapelido, p.anidatanasc, p.aniobservacoes, p.espid, p.cliid, p.aniid);
    }
    public Task<List<animal>> Delete(int aniid)
    {
        string sql = "DELETE FROM Animal Where aniid=?";
        return connection.QueryAsync<animal>(sql, aniid);
    }
    public Task<List<animal>> GetAll()
    {
        return connection.Table<animal>().ToListAsync();
    }
    public Task<List<animal>> Search(string p)
    {
        string sql = "SELECT * FROM Animal WHERE aninome LIKE ?";
        return connection.QueryAsync<animal>(sql, $"%{p}%");
    }
}