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

namespace EHR_Application.Models
{
    class NewVisit
    {
        public int DoctorPersonID { get; set; }
        public int PersonID { get; set; }
        public string Date { get; set; }
    }
}