using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_GuateFinanzas.Models
{
    public class CreditCard
    {
        [Display(Name = "Number Credit Card")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }

        [Required]
        [Display(Name = "DPI")]
        public Int64 PersonID { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Pin { get; set; }

        [Required]
        public Enumeration.CreditCardType Type { get; set; }

        [Required]
        public Enumeration.State State { get; set; }

        [Required]
        public Int64 CreditLimit { get; set; }

        [Required]
        public int Rate { get; set; }

        //[Display(Name = "Payment Due Date")]
        //public DateTime PaymentDueDate 
        //{  
        //    get
        //    {
        //        if()
        //        {}
        //    }
        //}

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
                DateTime ActivationTime = ActivationDate;
                ActivationTime.AddYears(5);
                return ActivationTime;
            }
        }

        public virtual Person Person { get; set; }
        public virtual ICollection<MovementCreditCard> MovementsCC { get; set; }
    }

    public class ManageStateCreditCard : RequestChangeState
    {
        //Request Change State Credit Card
        public virtual ICollection<ManageStateCreditCard> RequestCSCC { get; set; }
    }
}