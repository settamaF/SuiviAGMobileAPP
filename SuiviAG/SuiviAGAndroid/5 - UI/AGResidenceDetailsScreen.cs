using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Views;

using SuiviAG.Core.Entity;

namespace SuiviAGAndroid.UI {

	[Activity (Label = "Residence Details")]			
	public class AGResidenceDetailsScreen : Activity {
		protected AGResidence agResidence = new AGResidence();
		protected Button cancelDeleteButton = null;
		protected Button cancelButton = null;
		protected EditText adresseTextEdit = null;
		protected EditText nameTextEdit = null;
		protected Button saveButton = null;
		protected LinearLayout AGResidenceDetailsLayout = null;

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

			int agResidenceID = Intent.GetIntExtra("AGResidenceID", 0);
			if(agResidenceID > 0) {
				agResidence = SuiviAG.Core.Business.AGManager.GetAGResidence(agResidenceID);
			}

			// set our layout to be the home screen
			SetContentView(Resource.Layout.AGResidenceDetails);
			nameTextEdit = FindViewById<EditText>(Resource.Id.txtAGResidenceName);
			adresseTextEdit = FindViewById<EditText> (Resource.Id.txtAGResidenceAdresse);
			saveButton = FindViewById<Button>(Resource.Id.btnAGResidenceSave);

			// find all our controls
			cancelDeleteButton = FindViewById<Button>(Resource.Id.btnAGResidenceCancelDelete);


			// set the cancel delete based on whether or not it's an existing choice
			if(cancelDeleteButton != null)
			{ cancelDeleteButton.Text = (agResidence.ID == 0 ? "Cancel" : "Delete"); }

			// name
			if(nameTextEdit != null) { nameTextEdit.Text = agResidence.Name; }

			// button clicks 
			cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
			saveButton.Click += (sender, e) => { Save(); };
		}

		protected void Save()
		{
			agResidence.Name = nameTextEdit.Text;
			agResidence.Adress = adresseTextEdit.Text;
			SuiviAG.Core.Business.AGManager.SaveAGResidence(agResidence);
			Finish();
		}

		protected void CancelDelete()
		{
			if(agResidence.ID != 0) {
				SuiviAG.Core.Business.AGManager.DeleteAGResidence(agResidence.ID);
			}
			Finish();
		}
	}
}