using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AlphaVet.Model;

public class animal
{
    [PrimaryKey, AutoIncrement]
    public int aniid { get; set; }

    [MaxLength(50)]
    public string aninome { get; set; }

    [MaxLength(25)]
    public string aniapelido { get; set; }

    public DateTime anidatanasc { get; set; }

    [MaxLength(500)]
    public string aniobservacoes { get; set; }

    public int espid { get; set; }

    public int cliid { get; set; }
}