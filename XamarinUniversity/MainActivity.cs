using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinUniversity
{
	[Activity (Label = "Instructors", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			var instructorsListView = FindViewById<ListView>(Resource.Id.instructorListView);
			instructorsListView.FastScrollEnabled = true;

			var instructors = InstructorData.Instructors;

			// var adapter = new ArrayAdapter<Instructor> (this, Android.Resource.Layout.SimpleListItem1, instructors);
			var adapter = new InstructorAdapter(this, instructors);

			instructorsListView.ItemClick += (sender, e) => {
				var dialog = new AlertDialog.Builder (this);
				dialog.SetMessage (instructors [e.Position].Name);
				dialog.SetNeutralButton ("Ok", delegate {});
				dialog.Show ();
			};

			instructorsListView.Adapter = adapter;
		}
	}
}


