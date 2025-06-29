using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using AlphaVet.Model;

namespace AlphaVet.Helpers;

public class clientesqlhelper

{
    readonly SQLiteAsyncConnection connection;
    public clientesqlhelper(string path)
    {
        connection = new SQLiteAsyncConnection(path);

        connection.CreateTableAsync<cliente>().Wait();
    }

    public Task<int> Insert(cliente p)
    {
        return connection.InsertAsync(p);
    }
    public Task<List<cliente>> Update(cliente p)
    {
        string sql = "UPDATE Cliente SET cliid=?, clinome=?, clicpf=?, cliemail=?, clidatacadastro=? WHERE cliid=?";
        return connection.QueryAsync<cliente>(sql, p.cliid, p.clinome, p.clicpf, p.cliemail, p.clidatacadastro, p.cliid);
    }
    public Task<List<cliente>> Delete(int cliid)
    {
        string sql = "DELETE FROM Cliente Where cliid=?";
        return connection.QueryAsync<cliente>(sql, cliid);
    }
    public Task<List<cliente>> GetAll()
    {
        return connection.Table<cliente>().ToListAsync();
    }
    public Task<List<cliente>> Search(string p)
    {
        string sql = "SELECT * FROM Cliente WHERE clinome LIKE ?";
        return connection.QueryAsync<cliente>(sql, $"%{p}%");
    }
}
