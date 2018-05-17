using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace quickmeal.Models
{
    public class Ulubiony
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("Id_Ulubionego")]
        public int Id { get; set; }

        [ForeignKey(typeof(Przepis)), Column("Id_Przepisu")]
        public int Id_Przepisu{ get; set; }

        public Ulubiony()
        { }
    }
}
