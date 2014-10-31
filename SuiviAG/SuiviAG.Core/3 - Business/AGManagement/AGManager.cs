using System;
using System.Collections.Generic;
using SuiviAG.Core.Entity;

namespace SuiviAG.Core.Business
{
	public static class AGManager
	{
		static AGManager ()
		{
		}

		public static AGTravaux GetAGTravaux(int id)
		{
			return DAL.AGRepository.GetAGTravaux(id);
		}

		public static IList<AGTravaux> GetAGTravaux()
		{
			return new List<AGTravaux>(DAL.AGRepository.GetAGTravaux ());
		}

		public static int SaveAGTravaux (AGTravaux item)
		{
			return DAL.AGRepository.SaveAGTravaux(item);
		}

		public static int DeleteAGTravaux(int id)
		{
			return DAL.AGRepository.DeleteAGTravaux(id);
		}

		public static AGResidence GetAGResidence(int id)
		{
			return DAL.AGRepository.GetAGResidence(id);
		}

		public static IList<AGResidence> GetAGResidence()
		{
			return new List<AGResidence>(DAL.AGRepository.GetAGResidence ());
		}

		public static int SaveAGResidence (AGResidence item)
		{
			return DAL.AGRepository.SaveAGResidence(item);
		}

		public static int DeleteAGResidence(int id)
		{
			return DAL.AGRepository.DeleteAGResidence(id);
		}

		public static AGDevis GetAGDevis(int id)
		{
			return DAL.AGRepository.GetAGDevis(id);
		}

		public static IList<AGDevis> GetAGDevis()
		{
			return new List<AGDevis>(DAL.AGRepository.GetAGDevis ());
		}

		public static int SaveAGDevis (AGDevis item)
		{
			return DAL.AGRepository.SaveAGDevis(item);
		}

		public static int DeleteAGDevis(int id)
		{
			return DAL.AGRepository.DeleteAGDevis(id);
		}

		public static AGFacture GetAGFacture(int id)
		{
			return DAL.AGRepository.GetAGFacture(id);
		}

		public static IList<AGFacture> GetAGFacture()
		{
			return new List<AGFacture>(DAL.AGRepository.GetAGFacture ());
		}

		public static int SaveAGFacture (AGFacture item)
		{
			return DAL.AGRepository.SaveAGFacture(item);
		}

		public static int DeleteAGFacture(int id)
		{
			return DAL.AGRepository.DeleteAGFacture(id);
		}

		public static AGEntreprise GetAGEntreprise(int id)
		{
			return DAL.AGRepository.GetAGEntreprise(id);
		}

		public static IList<AGEntreprise> GetAGEntreprise()
		{
			return new List<AGEntreprise>(DAL.AGRepository.GetAGEntreprise ());
		}

		public static int SaveAGEntreprise (AGEntreprise item)
		{
			return DAL.AGRepository.SaveAGEntreprise(item);
		}

		public static int DeleteAGEntreprise(int id)
		{
			return DAL.AGRepository.DeleteAGEntreprise(id);
		}
	}
}

