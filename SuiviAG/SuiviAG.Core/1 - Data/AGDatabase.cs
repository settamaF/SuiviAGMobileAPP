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
			CreateTable<AGResidence> ();
			CreateTable<AGEntreprise> ();
			CreateTable<AGTravaux> ();
			CreateTable<AGDevis> ();
			CreateTable<AGFacture> ();
			ClearDatabase ();
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

		//Function to clear all data
		public void ClearDatabase()
		{
			this.DeleteAll<AGTravaux> ();
			this.DeleteAll<AGResidence> ();
			this.DeleteAll<AGEntreprise> ();
			this.DeleteAll<AGDevis> ();
			this.DeleteAll<AGFacture> ();
		}

		//Function to init database for sample
		public void InitDatabase()
		{
			if (this.Table<AGResidence> ().Count () == 0)
				this.InitDatabaseResidence ();
			if (this.Table<AGEntreprise> ().Count () == 0)
				this.InitDatabaseEntreprise ();
			if (this.Table<AGTravaux> ().Count () == 0)
				this.InitDatabaseTravaux ();
		}

		private void InitDatabaseResidence()
		{
			var newResidence = new AGResidence ();
			newResidence.Name = "Clos bastille";
			newResidence.Adress = "Inconnu";
			this.Insert (newResidence);
			newResidence.Name = "Espace Republique";
			newResidence.Adress = "Inconnu";
			this.Insert (newResidence);
			newResidence.Name = "Refuge";
			newResidence.Adress = "Inconnu";
			this.Insert (newResidence);
			newResidence.Name = "Robert";
			newResidence.Adress = "Inconnu";
			this.Insert (newResidence);
			newResidence.Name = "Villas Olympe";
			newResidence.Adress = "Inconnu";
			this.Insert (newResidence);
			newResidence.Name = "Hibicus";
			newResidence.Adress = "Inconnu";
			this.Insert (newResidence);
			newResidence.Name = "Aromes";
			newResidence.Adress = "Inconnu";
			this.Insert (newResidence);
			newResidence.Name = "Belem1";
			newResidence.Adress = "Inconnu";
			this.Insert (newResidence);
		}

		private void InitDatabaseTravaux()
		{
			var newTravaux = new AGTravaux ();
			newTravaux.DateVote = new DateTime(2014, 05, 27);
			newTravaux.DateEcheance = new DateTime(2014, 08, 12);
			newTravaux.Motif = "Expertise Tech";
			newTravaux.AppelFond = false;
			newTravaux.Avancement = 0;
			newTravaux.Note = "A faire au 01/05/2015";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Clos bastille")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 27);
			newTravaux.DateEcheance = new DateTime(2014, 08, 12);
			newTravaux.Motif = "Tvx Portail accés parking";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 100;
			newTravaux.Note = "SAR";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Clos bastille")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 27);
			newTravaux.DateEcheance = new DateTime(2014, 08, 12);
			newTravaux.Motif = "Refection electricité coursive";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 50;
			newTravaux.Note = "SIDE";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Clos bastille")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 27);
			newTravaux.DateEcheance = new DateTime(2014, 08, 12);
			newTravaux.Motif = "Fond de trx futurs";
			newTravaux.AppelFond = false;
			newTravaux.Avancement = 0;
			newTravaux.Note = "";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Clos bastille")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 04, 15);
			newTravaux.DateEcheance = new DateTime(2014, 07, 22);
			newTravaux.Motif = "Rénovation carrelage explande";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 100;
			newTravaux.Note = "NCIS";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Espace Republique")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 05);
			newTravaux.DateEcheance = new DateTime(2014, 08, 02);
			newTravaux.Motif = "Fond de trx futurs";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 25;
			newTravaux.Note = "";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Refuge")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 05);
			newTravaux.DateEcheance = new DateTime(2014, 08, 02);
			newTravaux.Motif = "Avance trésorerie";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 50;
			newTravaux.Note = "";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Refuge")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 28);
			newTravaux.DateEcheance = new DateTime(2014, 08, 10);
			newTravaux.Motif = "Mises aux normes comteurs eaux";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 25;
			newTravaux.Note = "EPJR";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Robert")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 28);
			newTravaux.DateEcheance = new DateTime(2014, 08, 10);
			newTravaux.Motif = "mises aux normes électriques";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 25;
			newTravaux.Note = "FILEOELEC";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Robert")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 26);
			newTravaux.DateEcheance = new DateTime(2014, 08, 11);
			newTravaux.Motif = "Rép. mat électrique";
			newTravaux.AppelFond = false;
			newTravaux.Avancement = 0;
			newTravaux.Note = "FILEOELEC";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Villas Olympe")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 05, 26);
			newTravaux.DateEcheance = new DateTime(2014, 08, 11);
			newTravaux.Motif = "Copie contrat assurance PNO à Mme LORION";
			newTravaux.AppelFond = false;
			newTravaux.Avancement = 0;
			newTravaux.Note = "";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Villas Olympe")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 03, 25);
			newTravaux.DateEcheance = new DateTime(2014, 05, 25);
			newTravaux.Motif = "MEP reducteur de pression d'eau";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 100;
			newTravaux.Note = "NCI";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Hibicus")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);

			newTravaux.DateVote = new DateTime(2014, 04, 22);
			newTravaux.DateEcheance = new DateTime(2014, 06, 22);
			newTravaux.Motif = "Fon de trx futures";
			newTravaux.AppelFond = true;
			newTravaux.Avancement = 25;
			newTravaux.Note = "";
			newTravaux.IdResidence = Table<AGResidence>().Where(v => v.Name.Contains("Hibicus")).FirstOrDefault().ID;
			newTravaux.IdEntreprise = Table<AGEntreprise>().Where(v => v.Name.Contains("Entreprise 1")).FirstOrDefault().ID;
			this.Insert(newTravaux);
		}

		private void InitDatabaseEntreprise()
		{
			var newEntreprise = new AGEntreprise ();
			newEntreprise.Name = "Entreprise 1";
			newEntreprise.Adress = "Inconnu";
			this.Insert (newEntreprise);
		}

		private void initDatabaseDevis()
		{

		}

		private void initDatabaseFacture()
		{
		}

	}
}

