using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AlphaVet.Model
{
    public class cliente
    {
        [PrimaryKey, AutoIncrement]
        public int cliid { get; set; }

        public string clinome { get; set; }

        public string clicpf { get; set; }

        public string cliemail { get; set; }

        public DateTime clidatacadastro { get; set; } = DateTime.Now;
    }
}