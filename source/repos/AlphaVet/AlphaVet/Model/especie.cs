using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AlphaVet.Model;

public class especie
{

        [PrimaryKey, AutoIncrement]
        public int espid { get; set; }

        public string espnome { get; set; }
}
