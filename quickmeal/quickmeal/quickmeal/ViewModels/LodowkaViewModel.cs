using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using quickmeal.Models;
namespace quickmeal.ViewModels
{
    public class LodowkaViewModel
    {
        MyDataSource.LodowkaData _context = new MyDataSource.LodowkaData();
        private ObservableCollection<Models.Lodowka> lodowkas;
        public ObservableCollection<Models.Lodowka> Lodowka
        {
            get { return lodowkas; }
            set { lodowkas = value; }
        }
        public LodowkaViewModel()
        {
            Lodowka = new ObservableCollection<Models.Lodowka>();

            foreach (var lodowka in _context.Lodowkas)
            {
                Lodowka.Add(lodowka);
            }

            Lodowka = new ObservableCollection<Models.Lodowka>(Lodowka.OrderBy(i => i.Id_Produktu));
        }

        public Command<Models.Lodowka> RefreshLodowka
        {
            get
            {
                return new Command<Models.Lodowka>((lodowka) =>
                {
                    Lodowka = new ObservableCollection<Models.Lodowka>(Lodowka.OrderBy(i => i.Id_Produktu));
                });
            }
        }

      

    }
}
