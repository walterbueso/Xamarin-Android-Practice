using Android.App;
using Android.Widget;
using Android.OS;
using XamarinUniversity;
using System;

namespace App2
{
    [Activity(Label = "App2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.ItemClick += OnItemClick;
            listView.FastScrollEnabled = true;

            var adapter = new InstructorAdapter(this, InstructorData.Instructors);
            listView.Adapter = adapter;
            

           
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //var instructor = InstructorData.Instructors[e.Position];
            //var dialog = new AlertDialog.Builder(this);
            //var message = "This is " + instructor.Name;

            //dialog.SetMessage(message);
            //dialog.SetNeutralButton("Ok", delegate { });
            //dialog.Show();
            StartActivity(typeof(ProfileActivity));
        }
    }
}

