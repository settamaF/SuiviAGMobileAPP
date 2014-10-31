using System;
using SuiviAG.Core.DataLayer;
using SuiviAG.Core.Business.IEntity;

namespace SuiviAG.Core.Entity
{
	public class AGEntreprise: EntityBase, IEntity
	{
		public AGEntreprise ()
		{
		}

		public string Name { get; set; }
		public string Adress {get; set; }
	}
}

