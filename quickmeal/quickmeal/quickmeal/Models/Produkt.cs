using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
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
        public string kategoria_produktu
        {
            get
            {
                try
                {
                    Kategoria kategoria = App.KategoriaRepo.GetAllKategoria().Where(x => x.Id == Id_Kategorii).FirstOrDefault();
                    if (kategoria.Nazwa != null)
                        return kategoria.Nazwa;
                    else return "Nieznane";
                }
                catch(Exception ex)
                {
                    return "Nieznane";
                }
            }
        }

        public Produkt()
        {
            Skladniki = new List<Skladnik>();
        }
    }
}
