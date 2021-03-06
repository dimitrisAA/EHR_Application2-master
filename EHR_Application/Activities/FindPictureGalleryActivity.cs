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
using Android.Provider;
using System.IO;
using Android.Graphics;

namespace EHR_Application
{
    [Activity(Label = "   FindPictureGallery  ")]
    public class FindPictureGalleryActivity : Activity
    {
        Bitmap bitmap;
        byte[] Picture_array;
        ImageView imageView;
        Byte[] Photopicture;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string text = Intent.GetStringExtra("MyString");
            //int k = 0;

            SetContentView(Resource.Layout.PickimLayout);
            Button button1 = FindViewById<Button>(Resource.Id.myButton);
            button1.Click += Button1_Click;
            Button button2 = FindViewById<Button>(Resource.Id.button1);
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SendDataActivity));
           // intent.PutExtra("intId", 4);
            //intent.PutExtra("image", Picture_array);
           // intent.PutExtra("BitmapImage", bitmap);
            StartActivity(intent);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"), 0);
        }
        
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                ////////////////////   try something new
                try { 
                        bitmap = (Bitmap)data.Extras.Get("data");
                        Photopicture = BitmapToByte();
                        var imageView = FindViewById<ImageView>(Resource.Id.myImageView);
                        imageView.SetImageURI(data.Data);
                /////////////////////   end of try
                    
                    //var imageView =
                    //    FindViewById<ImageView>(Resource.Id.myImageView);
                    //imageView.SetImageURI(data.Data);

                    //try          //  get the bytes from the image
                    //{
                    //    bitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, data.Data);
                    //    using (MemoryStream stream = new MemoryStream())
                    //    {
                    //        bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                    //         Picture_array = stream.ToArray();
                    //    }
                }
                catch 
                {
                    new AlertDialog.Builder(this)
                .SetTitle("An error has occured")
                .SetMessage("The picture is very big"+ "\n" + "to be send!!")
                .SetIcon(Resource.Drawable.error)
                .Show();
                }
            }
        }

        protected byte[] BitmapToByte()
        {
            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
            byte[] bitmapData = stream.ToArray();
            return bitmapData;
        }
    }
}