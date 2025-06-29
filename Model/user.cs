using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AlphaVet.Model;

public class user
{

    [PrimaryKey, AutoIncrement]
    public int userid { get; set; }

    public string username { get; set; }

    public string userpass { get; set; }
}
