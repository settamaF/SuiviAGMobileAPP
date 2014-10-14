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
	}
}

