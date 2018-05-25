using System;
using System.Collections.Generic;
using System.Text;
using quickmeal.Models;

namespace quickmeal.MyDataSource
{
    class LodowkaData
    {
        public List<Lodowka> Lodowkas = new List<Lodowka>();
        public LodowkaData()
        {
            Lodowkas = App.LodowkaRepo.GetAllProdukt();
        }
    }
}
