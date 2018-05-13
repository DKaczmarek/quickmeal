using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
using SQLiteNetExtensions.Attributes;
namespace quickmeal.Models
{
    [Table("Przepis")]
    public class Przepis
    {
        [PrimaryKey,AutoIncrement,NotNull,Column("Id_Przepisu")]
        public int Id { get; set; }

        [ForeignKey(typeof(Typ)), Column("Id_Typu")]
        public int Id_Typu { get; set; }

        [Column("Nazwa")]
        public string Nazwa { get; set; }

        [NotNull,Column ("Opis")]
        public string Opis { get; set; }

        [Column("Czas")]
        public int Czas { get; set; }

        [Column("Zdjecie")]
        public string Zdjecie { get; set; }

        [OneToMany]
        public List<Skladnik> Zawiera { get; set; }

        public Przepis(string nazwa, string opis, int czas, string zdjecie)
        {
            Nazwa = nazwa;
            Opis = opis;
            Czas = czas;
            Zdjecie = zdjecie;

            Zawiera = new List<Skladnik>();
        }

        public Przepis()
        {
            Zawiera = new List<Skladnik>();
        }

    }
}
