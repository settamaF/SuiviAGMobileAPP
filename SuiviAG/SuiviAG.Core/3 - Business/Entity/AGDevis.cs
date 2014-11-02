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

		private AGTravaux _Travaux;
		[Ignore]
		public AGTravaux Travaux
		{
			get
			{
				if (this._Travaux == null)
					this._Travaux = SuiviAG.Core.Business.AGManager.GetAGTravaux (IdTravaux);
				return this._Travaux;
			}
			set
			{
				_Travaux = value;
			}
		}

		private AGEntreprise _Entreprise;
		[Ignore]
		public AGEntreprise Entreprise {
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

		private AGFacture _Facture;
		[Ignore]
		public AGFacture Facture 
		{
			get
			{
				if (this._Facture == null)
					this._Facture = SuiviAG.Core.Business.AGManager.GetAGFacture (IdFacture);
				return this._Facture;
			}
			set
			{
				_Facture = value;
			}
		}
	}
}

