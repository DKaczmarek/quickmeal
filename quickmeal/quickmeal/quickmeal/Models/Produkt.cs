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

        [Column("Gramatura")]
        public string Gramatura { get; set; }

        [OneToMany]
        public List<Skladnik> Skladniki { get; set; }

        [OneToOne]
        public Lodowka Posiada { get; set; }

        public int Ilosc;
        public Produkt(string nazwa, string gramatura)
        {
            Nazwa = nazwa;
            Gramatura = gramatura;
            Skladniki = new List<Skladnik>();
        }

        public Produkt()
        {
            Skladniki = new List<Skladnik>();
        }
    }
}
