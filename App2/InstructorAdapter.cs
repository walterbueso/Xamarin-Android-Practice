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
using XamarinUniversity;
using System.IO;
using Android.Graphics.Drawables;
using Java.Lang;

namespace App2
{
    class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
    {
        Java.Lang.Object[] sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(InstructorData.Instructors);
        Dictionary<int, int> positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(InstructorData.Instructors);
        Dictionary<int, int> sectionForPostionMap = SectionIndexerBuilder.BuildSectionForPositionMap(InstructorData.Instructors);

        private Activity context;
        private List<Instructor> instructors;

        public InstructorAdapter(Activity context, List<Instructor> instructors)
        {
            this.context = context;
            this.instructors = instructors;
        }
        public override Instructor this[int position]
        {
            get
            {
                return instructors[position];
            }
        }

        public override int Count
        {
            get
            {
                return instructors.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public int GetPositionForSection(int sectionIndex)
        {
            return positionForSectionMap[sectionIndex];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPostionMap[position];
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if(convertView == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.InstructorCard, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageViewCard);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextViewCard);
                //var special = view.FindViewById<TextView>(Resource.Id.specialtyTextView);

                view.Tag = new ViewHolder() { Photo = photo, Name = name };
            }

            var holder = (ViewHolder)view.Tag;  

            holder.Photo.SetImageDrawable(ImageAssetManager.Get(context, instructors[position].ImageUrl));
            holder.Name.Text = instructors[position].Name;
            //holder.Specialty.Text = instructors[position].Specialty;

            return view;
        }
    }
}