using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace quickmeal.Models
{
    [Table("Kategoria")]
    public class Kategoria
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("Id_Kategorii")]
        public int Id { get; set; }

        [NotNull, Column("Nazwa")]
        public string Nazwa { get; set; }

        [OneToMany]
        public List<Produkt> Produkty { get; set; }

        public Kategoria(string nazwa)
        {
            Nazwa = nazwa;
        }

        public Kategoria()
        {

        }
    }
}
