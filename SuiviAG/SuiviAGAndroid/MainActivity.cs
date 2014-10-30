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
		protected Button addAGTravauxBtn = null;
		protected Button lstAGTravauxBtn = null;
		protected Button lstAGResidenceBtn = null;
		protected ImageButton srcAG = null;
		protected EditText txtAGSrc = null;

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

			txtAGSrc = FindViewById<EditText> (Resource.Id.txtAGSrc);

			addAGTravauxBtn = FindViewById<Button> (Resource.Id.AddAGTravauxButton);
			if (addAGTravauxBtn != null) {
				addAGTravauxBtn.Click += (sender, e) => {
					StartActivity (typeof(AGResidenceDetailsScreen));
				};
			}

			addAGTravauxBtn = FindViewById<Button> (Resource.Id.AddAGTravauxButton);
			if (addAGTravauxBtn != null) {
				addAGTravauxBtn.Click += (sender, e) => {
					StartActivity (typeof(AGResidenceDetailsScreen));
				};
			}
//			srcAG = FindViewById<ImageButton> (Resource.Id.btnAGSrc);
//			if (srcAG != null) {
//				srcAG.Click += (sender, e) => {
//					SrcResidence();
//				};
//			}
			lstAGResidenceBtn = FindViewById<Button> (Resource.Id.lstAGResidenceButton);
			if (lstAGResidenceBtn != null) {
				lstAGResidenceBtn.Click += (sender, e) => {
					StartActivity(typeof(AGResidenceListScreen));
				};
			}
			lstAGTravauxBtn = FindViewById<Button> (Resource.Id.lstAGTravauxButton);
			if (lstAGTravauxBtn != null) {
				lstAGTravauxBtn.Click += (sender, e) => {
					StartActivity(typeof(AGTravauxListScreen));
				};
			}
		}

		/*protected void SrcResidence()
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
		}*/
	}
}


