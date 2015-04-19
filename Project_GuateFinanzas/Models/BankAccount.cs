using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_GuateFinanzas.Models
{
    public class BankAccount
    {
        [Required]
        [Display(Name = "Account Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }

        [Required]
        [Display(Name = "DPI")]
        public Int64 PersonID { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Account Name")]
        public string Name { get; set; }

        public double Balance { get; set; }

        [Required]
        public Enumeration.AccountType Type { get; set; }

        [Required]
        public Enumeration.State State { get; set; }

        [Required]
        [Display(Name = "First Laboral Reference Name")]
        [StringLength(50, MinimumLength = 10)]
        public string LRN1st { get; set; }

        [Phone]
        [Required]
        [StringLength(11, MinimumLength = 8)]
        [Display(Name = "First Laboral Reference Number Phone")]
        public string LRNP1st { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Second Laboral Reference Name")]
        public string LRN2nd { get; set; }

        [Phone]
        [Required]
        [StringLength(11, MinimumLength = 8)]
        [Display(Name = "Second Laboral Reference Number Phone")]
        public string LRNP2nd { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<DebitCard> DebitCards { get; set; }
        public virtual ICollection<AccountMovement> AccountMovements { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }

    public class ManageStateAccount : RequestChangeState
    {
        //Request Change State Bank Account
        public virtual ICollection<ManageStateAccount> RequestCSBA { get; set; }
    }
}