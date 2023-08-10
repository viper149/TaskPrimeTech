using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeTechApp.Models
{
    public class Company
    {
        public int ID { get; set; }
        [Display(Name = "ID")]
        [Required]
        public int CID { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string CNAME { get; set; }
        [Display(Name = "Address")]
        public string CADDRESS { get; set; }

        [NotMapped]
        [Display(Name = "Enter Extra Field Name:")]
		public string ExtraField { get; set; }
    }
}