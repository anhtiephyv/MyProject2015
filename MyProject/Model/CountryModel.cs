using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MyProject.Model
{
    public class CountryModel
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public byte[] CountryFlag { get; set; }
        public string CountryCronyms { get; set; }
        public string FileUploadName { get; set; }
        public string FileUploadType { get; set; }
        public byte[] FileUpload { get; set; }
        public int CountryStatus { get; set; }
    }
}
