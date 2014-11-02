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
	[Activity (Label = "Liste des travaux")]			
	public class AGTravauxListScreen : Activity
	{
		protected Application.AGTravauxAdapter agTravauxList;
		protected IList<AGTravaux> agTravaux;
		protected ListView agTravauxListView = null;

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

			SetContentView (Resource.Layout.AGTravauxListScreen);
			agTravauxListView = FindViewById<ListView> (Resource.Id.listTravaux);


			agTravauxListView.ItemClick += (sender, e) => 
			{
				var agTravauxDetailActivity = new Intent (this, typeof(AGTravauxDetailsScreen));
				agTravauxDetailActivity.PutExtra("AGTravauxId", agTravaux[e.Position].ID);
				StartActivity(agTravauxDetailActivity);
			};
		}

		protected override void OnResume()
		{
			base.OnResume ();

			agTravaux = SuiviAG.Core.Business.AGManager.GetAGTravaux ();
			agTravauxList = new SuiviAGAndroid.Application.AGTravauxAdapter(this, agTravaux);
			agTravauxListView.Adapter = agTravauxList;
		}
	}
}

