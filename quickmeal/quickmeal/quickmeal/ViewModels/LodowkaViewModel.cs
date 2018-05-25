using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

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
        public Command<Models.Lodowka> InsertCommand
        {
            get
            {
                return new Command<Models.Lodowka>((lodowka) =>
                {
                    Lodowka.Insert(0, lodowka);
                });
            }
        }

        public Command<Models.Lodowka> RemoveCommand
        {
            get
            {
                return new Command<Models.Lodowka>((lodowka) =>
                {
                    Lodowka.Remove(lodowka);
                });
            }
        }

        public Command<Models.Lodowka> UpdateCommand
        {
            get
            {
                return new Command<Models.Lodowka>((lodowka) =>
                {
                    Lodowka.Remove(lodowka);
                    Lodowka.Insert(Lodowka.IndexOf(lodowka), lodowka);
                });
            }
        }

    }
}
