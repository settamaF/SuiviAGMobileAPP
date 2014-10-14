﻿using System;
using System.Collections.Generic;
using System.IO;
using SuiviAG.Core.Entity;
using SuiviAG.Core.DataLayer;

namespace SuiviAG.Core.DAL
{
	public class AGRepository
	{
		AGDatabase db = null;
		protected static string dbLocation;
		protected static AGRepository me;

		static AGRepository ()
		{
			me = new AGRepository ();
		}

		protected AGRepository()
		{
			dbLocation = DatabaseFilePath;
			db = new AGDatabase(dbLocation);
		}

		public static string DatabaseFilePath
		{
			get
			{
				var sqliteFilename = "AG.db3";
				#if NETFX_CORE
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
				#else

				#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
				#else

				#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
				#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
				#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
				#endif		

				#endif
				return path;	
			}
		}

		public static AGTravaux GetAGTravaux(int id)
		{
			return me.db.GetItem<AGTravaux>(id);
		}

		public static IEnumerable<AGTravaux> GetAGTravaux ()
		{
			return me.db.GetItems<AGTravaux>();
		}

		public static int SaveAGTravaux (AGTravaux item)
		{
			return me.db.SaveItem<AGTravaux>(item);
		}

		public static int DeleteAGTravaux(int id)
		{
			return me.db.DeleteItem<AGTravaux>(id);
		}

		public static AGResidence GetAGResidence(int id)
		{
			return me.db.GetItem<AGResidence>(id);
		}

		public static IEnumerable<AGResidence> GetAGResidence ()
		{
			return me.db.GetItems<AGResidence>();
		}

		public static int SaveAGResidence (AGResidence item)
		{
			return me.db.SaveItem<AGResidence>(item);
		}

		public static int DeleteAGResidence(int id)
		{
			return me.db.DeleteItem<AGResidence>(id);
		}
	}
}
