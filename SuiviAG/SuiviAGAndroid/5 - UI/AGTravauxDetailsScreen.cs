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

using SuiviAG.Core.Entity;
using Android.Graphics;
using System.Globalization;

namespace SuiviAGAndroid.UI
{
	[Activity (Label = "Travaux Details")]			
	public class AGTravauxDetailsScreen : Activity, View.IOnClickListener
	{
		protected AGTravaux agTravaux = new AGTravaux();
		protected Button cancelDeleteButton = null;
		protected Button saveButton = null;
		protected EditText motifTextEdit = null;
		protected EditText residenceTextEdit = null;
		protected EditText dateVoteTextEdit = null;
		protected EditText dateEcheanceTextEdit = null;
		protected SeekBar avancementSeekBar = null;
		protected EditText noteTextEdit = null;

		private DatePickerDialog dateVoteDialog;
		private DatePickerDialog dateEcheanceDialog;
		private DateTime _date;

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

			int agTravauxID = Intent.GetIntExtra ("AGTravauxId", 0);
			if (agTravauxID > 0) {
				agTravaux = SuiviAG.Core.Business.AGManager.GetAGTravaux (agTravauxID);
			}

			// set our Layout to be the home screen
			SetContentView (Resource.Layout.AGTravauxDetails);
			motifTextEdit = FindViewById<EditText> (Resource.Id.txtAGTravauxMotif);
			residenceTextEdit = FindViewById<EditText> (Resource.Id.txtAGResidence);
			dateVoteTextEdit = FindViewById<EditText> (Resource.Id.txtAGTravauxDateVote);
			dateEcheanceTextEdit = FindViewById<EditText> (Resource.Id.txtAGTravauxDateEcheance);
			avancementSeekBar = FindViewById<SeekBar> (Resource.Id.AGTravauxAvancementSeekBar);
			noteTextEdit = FindViewById<EditText> (Resource.Id.txtAGTravauxNote);


			//find all our controls
			saveButton = FindViewById<Button>(Resource.Id.btnAGTravauxSave);
			cancelDeleteButton = FindViewById<Button>(Resource.Id.btnAGTravauxCancelDelete);

			if(cancelDeleteButton != null)
			{ cancelDeleteButton.Text = (agTravaux.ID == 0 ? "Annuler" : "Supprimer"); }


			if(motifTextEdit != null) { motifTextEdit.Text = agTravaux.Motif; }
			if(residenceTextEdit != null)
			{
				if (agTravaux.Residence != null)
					residenceTextEdit.Text = agTravaux.Residence.Name;
				else
					residenceTextEdit.Text = "";
			}
			if (dateVoteTextEdit != null)
			{
				if (agTravaux.DateVote != null)
					dateVoteTextEdit.Text = agTravaux.DateVote.ToString ("d", CultureInfo.CreateSpecificCulture ("fr-FR"));
				else
					dateVoteTextEdit.Text = DateTime.Today.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));
			}
			if (dateEcheanceTextEdit != null)
			{
				if (agTravaux.DateEcheance != null)
					dateEcheanceTextEdit.Text = agTravaux.DateEcheance.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));
				else
					dateEcheanceTextEdit.Text = DateTime.Today.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));
			}
			if (noteTextEdit != null) 
			{
				noteTextEdit.Text = agTravaux.Note;
			}
			if (avancementSeekBar != null) 
			{
				avancementSeekBar.Progress = agTravaux.Avancement;
			}

			// button clicks 
			cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
			saveButton.Click += (sender, e) => { Save(); };

			//datepicker event
			dateVoteTextEdit.SetOnClickListener (this);
			dateEcheanceTextEdit.SetOnClickListener (this);
			_date = DateTime.Today;
			dateVoteDialog = new DatePickerDialog (this, HandleDateVoteSet, _date.Year, _date.Month- 1, _date.Day);
			dateEcheanceDialog = new DatePickerDialog (this, HandleDateEcheanceSet, _date.Year, _date.Month- 1, _date.Day);

			//residence choice event
		}

		protected void Save()
		{
			SuiviAG.Core.Business.AGManager.SaveAGTravaux(agTravaux);
			Finish();
		}

		protected void CancelDelete()
		{
			if(agTravaux.ID != 0) {
				SuiviAG.Core.Business.AGManager.DeleteAGResidence(agTravaux.ID);
			}
			Finish();
		}

		public void OnClick(View v)
		{
			if (v == dateVoteTextEdit)
				dateVoteDialog.Show ();
			else if (v == dateEcheanceTextEdit)
				dateEcheanceDialog.Show ();
		}

		void HandleDateVoteSet(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			_date = e.Date;
			dateVoteTextEdit.Text = _date.ToString ("d", CultureInfo.CreateSpecificCulture ("fr-FR"));
		}

		void HandleDateEcheanceSet(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			_date = e.Date;
			dateEcheanceTextEdit.Text = _date.ToString("d", CultureInfo.CreateSpecificCulture ("fr-FR"));
		}
	}
}

