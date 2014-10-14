using System;
using SuiviAG.Core.DataLayer;
using SuiviAG.Core.Business.IEntity;

namespace SuiviAG.Core.Entity
{
	public class AGResidence : EntityBase, IEntity
	{
		public AGResidence ()
		{
		}

		public string Name {get; set;}
		public string Adress {get; set;}
	}
}

