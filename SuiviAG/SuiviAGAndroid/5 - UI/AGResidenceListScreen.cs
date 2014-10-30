
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

using SuiviAG.Core.Entity;

namespace SuiviAGAndroid.UI
{
	[Activity (Label = "AGResidenceListScreen")]			
	public class AGResidenceListScreen : Activity
	{
		protected Application.AGResidenceAdapter agResidenceList;
		protected IList<AGResidence> agResidences;
		protected ListView agResidenceListView = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			View titleView = Window.FindViewById(Android.Resource.Id.Title);
			if (titleView != null) {
				IViewParent parent = titleView.Parent;
				if (parent != null && (parent is View)) {
					View parentView = (View)parent;
					parentView.SetBackgroundColor(Color.Rgb(0x26, 0x75 ,0xFF)); //38, 117 ,255
				}
			}

			SetContentView (Resource.Layout.AGResidenceListScreen);
			agResidenceListView = FindViewById<ListView> (Resource.Id.listResidence);

		}

		protected override void OnResume()
		{
			base.OnResume ();

			agResidences = SuiviAG.Core.Business.AGManager.GetAGResidence ();
			agResidenceList = new SuiviAGAndroid.Application.AGResidenceAdapter (this, agResidences);
			agResidenceListView.Adapter = agResidenceList;
		}
	}
}

