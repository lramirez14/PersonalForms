using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalForms.Models
{
    public class PersonalViewModel
    {
        public Guid Personal_Id { get; set; }
        public string Personal_Identification { get; set; }
        public string Personal_FirstName { get; set; }
        public string Personal_LastName { get; set; }
        public string Personal_Phone { get; set; }

    }
}