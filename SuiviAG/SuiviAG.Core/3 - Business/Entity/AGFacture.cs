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

		private AGEntreprise _Entreprise;
		[Ignore]
		public AGEntreprise Entreprise
		{
			get
			{
				if (this._Entreprise == null)
					this._Entreprise = SuiviAG.Core.Business.AGManager.GetAGEntreprise (IdEntreprise);
				return this._Entreprise;
			}
			set
			{
				_Entreprise = value;
			}
		}
	}
}

