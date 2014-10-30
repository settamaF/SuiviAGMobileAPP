using System;
using System.Linq;
using SuiviAG.Core.Entity;
using SuiviAG.Core.Business.IEntity;
using System.Collections.Generic;

namespace SuiviAG.Core.DataLayer
{
	public class AGDatabase : SQLiteConnection
	{
		static object locker = new object();

		public AGDatabase (string path) : base (path)
		{
			CreateTable<AGTravaux> ();
			CreateTable<AGResidence> ();
			InitDatabase ();
		}

		public IEnumerable<T> GetItems<T> () where T : IEntity, new ()
		{
			lock (locker) {
				return (from i in Table<T> () select i).ToList ();
			}
		}

		public IEnumerable<T> GetItems<T> (Func<T,bool> predicate) where T : IEntity, new ()
		{
			lock (locker) {
				return Table<T>().Where(predicate);
			}
		}

		public T GetItem<T> (int id) where T : IEntity, new ()
		{
			lock (locker) {
				return Table<T>().FirstOrDefault(x => x.ID == id);
				// Following throws NotSupportedException - thanks aliegeni
				//return (from i in Table<T> ()
				//        where i.ID == id
				//        select i).FirstOrDefault ();
			}
		}

		public int SaveItem<T> (T item) where T : IEntity
		{
			lock (locker) {
				if (item.ID != 0) {
					Update (item);
					return item.ID;
				} else {
					return Insert (item);
				}
			}
		}

		public int DeleteItem<T>(int id) where T : IEntity, new ()
		{
			lock (locker) {
				#if NETFX_CORE
				return Delete(new T() { ID = id });
				#else
				return Delete<T> (new T () { ID = id });
				#endif
			}
		}

		//Function to init database for sample
		public void InitDatabase()
		{
			if (this.Table<AGResidence> ().Count () == 0)
				this.InitDatabaseResidence ();



			if (this.Table<AGTravaux> ().Count () == 0)
				this.InitDatabaseTravaux ();
		}

		private void InitDatabaseResidence()
		{
			var newResidence = new AGResidence ();
			newResidence.Name = "Clos bastille";
			newResidence.Adress = "";
			this.Insert (newResidence);
			newResidence.Name = "Espace Republique";
			newResidence.Adress = "";
			this.Insert (newResidence);
			newResidence.Name = "Refuge";
			newResidence.Adress = "";
			this.Insert (newResidence);
			newResidence.Name = "Robert";
			newResidence.Adress = "";
			this.Insert (newResidence);
			newResidence.Name = "Villas Olympe";
			newResidence.Adress = "";
			this.Insert (newResidence);
			newResidence.Name = "Hibicus";
			newResidence.Adress = "";
			this.Insert (newResidence);
			newResidence.Name = "Aromes";
			newResidence.Adress = "";
			this.Insert (newResidence);
			newResidence.Name = "Belem1";
			newResidence.Adress = "";
			this.Insert (newResidence);
		}

		private void InitDatabaseTravaux()
		{

		}

		private void InitDatabaseEntreprise()
		{

		}

		private void initDatabaseDevis()
		{

		}

		private void initDatabaseFacture()
		{
		}

	}
}

