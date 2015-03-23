using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.OS;
using Android.App;
using Android.Graphics.Drawables;
using System.IO;

namespace XamarinUniversity
{
	public class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
	{
		Activity context;
		List<Instructor> instructors;

		Java.Lang.Object[] sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(InstructorData.Instructors);
		Dictionary<int, int> positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(InstructorData.Instructors);
		Dictionary<int, int> sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(InstructorData.Instructors);

		public InstructorAdapter (Activity context, List<Instructor> instructors)
		{
			this.context = context;
			this.instructors = instructors;
		}

		public override long GetItemId (int position)
		{
			return position;
		}
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			View view = convertView;

			if (view == null) 
			{
				view = context.LayoutInflater.Inflate (Resource.Layout.InstructorRow, parent, false);

				var photoImageView = view.FindViewById<ImageView> (Resource.Id.photoImageView);
				var nameTextView = view.FindViewById<TextView> (Resource.Id.nameTextView);
				var specialtyTextView = view.FindViewById<TextView> (Resource.Id.specialtyTextView);

				view.Tag = new ViewHolder (){ Photo = photoImageView, Name = nameTextView, Specialty = specialtyTextView };
			}

			var holder = (ViewHolder)view.Tag;

			holder.Photo.SetImageDrawable (ImageAssetManager.Get(context, instructors[position].ImageUrl));
			holder.Name.Text = instructors [position].Name;
			holder.Specialty.Text = instructors [position].Specialty;

			return view;
		}
		public override int Count {
			get {
				return instructors.Count;
			}
		}

		public override Instructor this [int index] {
			get {
				return instructors [index];
			}
		}

		public int GetPositionForSection (int sectionIndex)
		{
			return positionForSectionMap[sectionIndex];
		}

		public int GetSectionForPosition (int position)
		{
			return sectionForPositionMap [position];
		}

		public Java.Lang.Object[] GetSections ()
		{
			return sectionHeaders;
		}
	}
}

