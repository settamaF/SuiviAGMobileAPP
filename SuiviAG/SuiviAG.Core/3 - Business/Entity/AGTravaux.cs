using System;
using SuiviAG.Core.DataLayer;
using SuiviAG.Core.Business.IEntity;

namespace SuiviAG.Core.Entity
{
	public class AGTravaux : EntityBase, IEntity
	{
		public AGTravaux ()
		{
		}

		public DateTime DateVote {get; set; }
		public DateTime DateEcheance {get; set;}
		public string Motif {get; set; }
		public bool AppelFond {get; set;}
		public int Avancement {get; set;}
		public string Note {get; set;}
		public int IdResidence {get; set;}
		public int IdEntreprise {get; set;}


		private AGResidence _Residence;
		[Ignore]
		public AGResidence Residence 
		{
			get 
			{ 
				if (this._Residence == null)
					this._Residence = SuiviAG.Core.Business.AGManager.GetAGResidence (IdResidence);
				return _Residence;
			} 
			set
			{
				_Residence = value;
			}
		}


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

