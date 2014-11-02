using System;
using System.Collections.Generic;
using Android.App;
using Android;
using SuiviAG.Core.Entity;
using Android.Widget;
using System.Globalization;
using SuiviAGAndroid.UI;
using Android.Content;

namespace SuiviAGAndroid.Application
{
	public class AGTravauxAdapter : BaseAdapter<AGTravaux>
	{
		protected Activity context = null;
		protected IList<AGTravaux> AGTravaux = new List<AGTravaux>();

		public AGTravauxAdapter (Activity context, IList<AGTravaux> Travaux) : base()
		{
			this.context = context;
			this.AGTravaux = Travaux;
		}

		public override AGTravaux this[int position]
		{
			get { return AGTravaux [position]; }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override int Count
		{
			get { return AGTravaux.Count;}
		}

		public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var item = AGTravaux [position];
			var view = (convertView ?? 
				context.LayoutInflater.Inflate(
					Resource.Layout.AGTravauxListItem, 
					parent, 
					false))   as LinearLayout;
			view.VerticalScrollBarEnabled = true;
			view.ScrollBarStyle = Android.Views.ScrollbarStyles.OutsideInset;

			// Find references to each subview in the list item's view
			var txtAGResidence = view.FindViewById<TextView> (Resource.Id.AGResidenceName);
			var txtMotif = view.FindViewById<TextView> (Resource.Id.Motif);
			var txtDateVote = view.FindViewById<TextView> (Resource.Id.DateVote);
			var txtDateEcheance = view.FindViewById<TextView> (Resource.Id.DateEcheance);
			var txtAvancement = view.FindViewById<TextView> (Resource.Id.AvancementValue);
			var progressBarAvancement = view.FindViewById<ProgressBar> (Resource.Id.Avancement);


			//Assign item's values to the various subviews
			this.setTextView(item.Residence.Name, txtAGResidence, 20);
			this.setTextView (item.Motif, txtMotif, 20);
			this.setTextView (item.DateVote.ToString ("d" , CultureInfo.CreateSpecificCulture("fr-FR")), txtDateVote, 20);
			this.setTextView (item.DateEcheance.ToString ("d" , CultureInfo.CreateSpecificCulture("fr-FR")), txtDateEcheance, 20);
			this.setTextView (item.Avancement.ToString () + "%", txtAvancement, 20);
			progressBarAvancement.Progress = item.Avancement;

			//Finally return the view
			return view;
		}

		private void setTextView(string value, TextView obj, float size)
		{
			obj.SetText (value, TextView.BufferType.Normal);
			//obj.SetTextSize(Android.Util.ComplexUnitType.Px, size);
		}
	}
}

