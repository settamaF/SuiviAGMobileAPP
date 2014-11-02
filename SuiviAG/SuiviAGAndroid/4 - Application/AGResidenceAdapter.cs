using System;
using Android.Widget;
using SuiviAG.Core.Entity;
using Android.App;
using Android;
using System.Collections.Generic;
using SuiviAGAndroid.UI;
using Android.Content;

namespace SuiviAGAndroid.Application
{
	public class AGResidenceAdapter : BaseAdapter<AGResidence>
	{
		protected Activity context = null;
		protected IList<AGResidence> AGResidences = new List<AGResidence>();

		public AGResidenceAdapter (Activity context, IList<AGResidence> AGResidences) : base()
		{
			this.context = context;
			this.AGResidences = AGResidences;
		}

		public override AGResidence this[int position]
		{
			get { return AGResidences [position]; }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override int Count
		{
			get { return AGResidences.Count;}
		}

		public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var item = AGResidences [position];
			var view = (convertView ?? 
				context.LayoutInflater.Inflate(
					Resource.Layout.AGResidenceListItem, 
					parent, 
					false))   as LinearLayout;
			view.VerticalScrollBarEnabled = true;
			view.ScrollBarStyle = Android.Views.ScrollbarStyles.OutsideInset;

			// Find references to each subview in the list item's view
			var txtName = view.FindViewById<TextView>(Resource.Id.txtName);
			var txtAdresse = view.FindViewById<TextView>(Resource.Id.txtAdresse);

			//Assign item's values to the various subviews
			txtName.SetText (item.Name, TextView.BufferType.Normal);
			txtName.SetTextSize (Android.Util.ComplexUnitType.Px, 35); 
			txtAdresse.SetText (item.Adress, TextView.BufferType.Normal);
			txtName.SetTextSize (Android.Util.ComplexUnitType.Px, 20); 

			//Finally return the view
			return view;
		}
	}
}

