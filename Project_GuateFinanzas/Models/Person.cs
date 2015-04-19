using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_GuateFinanzas.Models
{
    public class Person
    {
        [Required]
        [Display(Name = "DPI")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"/^[0-9]{4}\s?[0-9]{5}\s?[0-9]{4}$/")]
        public Int64 ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string SurName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [StringLength(50,MinimumLength = 5)]
        public string Address { get; set; }

        [Phone]
        [Display(Name = "Personal Phone Number")]
        public string PhoneNumber { get; set; }

        public string FullName 
        {
            get
            {
                return Name.Trim() + " " + SurName.Trim();
            }
        }

        [StringLength(60, MinimumLength = 10)]
        [Display(Name = "First Personal Reference Name")]
        //First personal reference name 
        public string PRN1st { get; set; }

        [Phone]
        [Display(Name = "First Personal Reference Number Phone")]
        //First personal reference phone number
        public string PRPN1st { get; set; }

        [StringLength(60, MinimumLength = 10)]
        [Display(Name = "Second Personal Reference Name")]
        //Second personal reference name
        public string PRN2nd { get; set; }

        [Phone]
        [Display(Name = "Second Personal Reference Number Phone")]
        //Second personal reference phone number
        public string PRPN2nd { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
    }
}