using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace quickmeal.Models
{
    [Table("Lodowka")]
    public class Lodowka
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("Id_Lodowki")]
        public int Id { get; set; }

        [ForeignKey(typeof(Produkt)), Column("Id_Produktu")]
        public int Id_Produktu { get; set; }

        [Column("Ilosc")]
        public int Ilosc { get; set; }

        public Lodowka(int ilosc)
        {
            Ilosc = ilosc;
        }

        public Lodowka()
        { }
    }
}
