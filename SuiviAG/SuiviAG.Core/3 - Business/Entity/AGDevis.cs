using System;
using SuiviAG.Core.DataLayer;
using SuiviAG.Core.Business.IEntity;

namespace SuiviAG.Core.Entity
{
	public class AGDevis : EntityBase, IEntity
	{
		public AGDevis ()
		{
		}

		public int IdTravaux {get; set;}
		public int IdEntreprise { get; set ; }
		public DateTime DateReception {get; set;}
		public DateTime DateRealisation {get; set;}
		public DateTime DateEcheance {get; set;}
		public int IdFacture {get; set;}
	}
}

