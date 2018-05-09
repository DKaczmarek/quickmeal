using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace quickmeal.Models
{
    [Table("Skladnik")]
    public class Skladnik
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("Id_Skladniku")]
        public int Id { get; set; }

        [Column("Gramatura")]
        public string Gramatura { get; set; }

        [Column("Ilosc")]
        public int Ilosc { get; set; }

        [ForeignKey(typeof(Przepis)), Column("Id_Przepisu")]
        public int Id_Przepisu { get; set; }

        [ForeignKey(typeof(Produkt)), Column("Id_Produktu")]
        public int Id_Produktu { get; set; }



        public Skladnik(string gramatura)
        {
            Gramatura = gramatura;
        }

        public Skladnik(int ilosc)
        {
            Ilosc = ilosc;
        }

        public Skladnik()
        {

        }
    }
}
