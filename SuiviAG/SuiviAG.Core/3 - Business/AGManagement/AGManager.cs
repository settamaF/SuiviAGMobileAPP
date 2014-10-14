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
	}
}

