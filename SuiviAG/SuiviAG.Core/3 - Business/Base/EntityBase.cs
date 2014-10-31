using System;
using SuiviAG.Core.DataLayer;
using SuiviAG.Core.Business.IEntity;

namespace SuiviAG.Core.Entity
{
	public abstract class EntityBase :IEntity 
	{
		public EntityBase ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
	}
}

