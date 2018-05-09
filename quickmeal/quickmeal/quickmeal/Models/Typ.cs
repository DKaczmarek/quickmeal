using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace quickmeal.Models
{
    [Table("Typ")]
    public class Typ
    {
        [PrimaryKey,AutoIncrement,NotNull,Column("Id_Typu")]
        public int Id { get; set; }

        [NotNull,Column("Nazwa")]
        public string Nazwa { get; set; }

        [OneToMany]
        public List<Przepis> Przepisy { get; set; }

        public Typ(string nazwa)
        {
            Nazwa = nazwa;
        }


        public Typ()
        {

        }

    }
}
