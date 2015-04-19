using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_GuateFinanzas.Models
{
    public class DebitCard
    {
        [Required]
        [Display(Name = "Number Debit Card")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }

        [Required]
        [Display(Name = "Number Account")]
        public Int64 BankAccountID { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Pin { get; set; }

        [Required]
        public Enumeration.State State { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Activation Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ActivationDate { get; set; }

        //[DataType(DataType.Date)]
        //[Display(Name = "Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime ExpirationDate 
        {
            get 
            {
                var ActivationTime = ActivationDate;
                ActivationTime.AddYears(5);
                return ActivationTime;
            }
        }

        public virtual BankAccount BankAccount { get; set; }
        public virtual ICollection<AccountMovement> DebitCardMovements { get; set; }
    }

    public class ManageStateDebitCard : RequestChangeState
    {
        //Request Change State Debit Card
        public virtual ICollection<ManageStateDebitCard> RequestCSDC { get; set; }
    }
}