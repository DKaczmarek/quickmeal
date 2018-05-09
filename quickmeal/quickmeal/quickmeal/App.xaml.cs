﻿using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using quickmeal.Models;
using quickmeal.Constants;
namespace quickmeal
{
	public partial class App : Application
	{
        private SQLite.SQLiteConnection dbConn;
        public static KategoriaRepository KategoriaRepo { get; set; }
        public static PrzepisRepository PrzepisRepo { get; set; }
        public static TypRepository TypRepo { get; set; }
        public static ProduktRepository ProduktRepo { get; set; }
        public static SkladnikRepository SkladnikRepo { get; set; }
        public App (string dbPath, ISQLitePlatform sqlitePlatform)
		{
            dbConn = new SQLite.SQLiteConnection(dbPath);
            KategoriaRepo = new KategoriaRepository(sqlitePlatform, dbPath);
            PrzepisRepo = new PrzepisRepository(sqlitePlatform, dbPath);
            TypRepo = new TypRepository(sqlitePlatform, dbPath);
            ProduktRepo = new ProduktRepository(sqlitePlatform, dbPath);
            SkladnikRepo = new SkladnikRepository(sqlitePlatform, dbPath);
            if (!Constant.DatabaseExist)
            {
                FillDatabase fill = new FillDatabase(sqlitePlatform, dbPath);
                fill.fill();
            }



            InitializeComponent();
			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
