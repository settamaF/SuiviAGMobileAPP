using System;
using SuiviAG.Core.DataLayer;
using SuiviAG.Core.Business.IEntity;

namespace SuiviAG.Core.Entity
{
	public class AGFacture :EntityBase, IEntity
	{
		public AGFacture ()
		{
		}

		public DateTime Date { get; set; }
		public float Prix { get; set;}
		public int IdEntreprise { get; set; }
	}
}

