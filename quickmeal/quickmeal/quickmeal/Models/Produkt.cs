using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace quickmeal.Models
{
    [Table("Produkt")]
    public class Produkt
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("Id_Produktu")]
        public int Id { get; set; }

        [ForeignKey(typeof(Kategoria)), Column("Id_Kategorii")]
        public int Id_Kategorii { get; set; }

        [NotNull, Column("Nazwa")]
        public string Nazwa { get; set; }

        [OneToMany]
        public List<Skladnik> Skladniki { get; set; }

        public Produkt(string nazwa)
        {
            Nazwa = nazwa;
        }

        public Produkt()
        {

        }
    }
}
