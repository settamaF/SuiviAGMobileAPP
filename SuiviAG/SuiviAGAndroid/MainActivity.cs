using System.Collections.Generic;
using SuiviAG.Core.Entity;
using SuiviAGAndroid.UI;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace SuiviAGAndroid
{
	[Activity (Label = "Suivi AG", MainLauncher = true, Icon = "@drawable/icon")]
	public class HomeScreen : Activity
	{
		protected Application.AGResidenceAdapter agResidenceList;
		protected IList<AGResidence> agResidences;
		protected Button addAGResidence = null;
		protected Button srcAGResidence = null;
		protected EditText txtAGResidenceSrc = null;
		protected ListView agResidenceListView = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			View titleView = Window.FindViewById (Android.Resource.Id.Title);
			if (titleView != null) {
				IViewParent parent = titleView.Parent;
				if (parent != null && (parent is View)) {
					View parentView = (View)parent;
					parentView.SetBackgroundColor (Color.Rgb (0x26, 0x75, 0xFF));
				}
			}
			agResidenceListView = FindViewById<ListView> (Resource.Id.listResidence);

			txtAGResidenceSrc = FindViewById<EditText> (Resource.Id.txtAGResidenceSrc);
			addAGResidence = FindViewById<Button> (Resource.Id.AddAGResidenceButton);
			if (addAGResidence != null) {
				addAGResidence.Click += (sender, e) => {
					StartActivity (typeof(AGResidenceDetailsScreen));
				};
			}
			srcAGResidence = FindViewById<Button> (Resource.Id.btnAGResidenceSrc);
			if (srcAGResidence != null) {
				srcAGResidence.Click += (sender, e) => {
					SrcResidence();
				};
			}
		}

		protected override void OnResume()
		{
			base.OnResume();

			agResidences = SuiviAG.Core.Business.AGManager.GetAGResidence ();
			agResidenceList = new SuiviAGAndroid.Application.AGResidenceAdapter (this, agResidences);
			agResidenceListView.Adapter = agResidenceList;
		}

		protected void SrcResidence()
		{
			IList <AGResidence> tmp = new List<AGResidence>();
			agResidences = SuiviAG.Core.Business.AGManager.GetAGResidence ();

			foreach (AGResidence res in agResidences) {
				if (res.Name.Contains(txtAGResidenceSrc.Text)) {
					tmp.Add (res);
				}
			}
			agResidences = tmp;
			agResidenceList = new SuiviAGAndroid.Application.AGResidenceAdapter (this, agResidences);
			agResidenceListView.Adapter = agResidenceList;
		}
	}
}


