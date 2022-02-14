using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.API.ModelValidation;

namespace Test.API.Models
{
    public class CreateTicketDto
    {
        //custom validation attribute
        [CreateTicketDto_EnsureTickeIdForTicketOwner]
        public int? TicketId { get; set; }
        [Required(ErrorMessage ="invalid value pass for project id")]
        public int? ProjectId { get; set; }

        [Required(ErrorMessage = "invalid value pass for title")]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        #region Owner must have a deudate their is custome validation attribute
        [StringLength(50)]
        public string Owner { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ReportDate { get; set; }


        //custom validation attribute
        [CreateTicketDto_EnsureDeuDateAndFutureDateForTicketOwner]
        //[CreateTicketDto_EnsureDeuDateIsFutureDate] we don need to have 2 custom avliation attribute on same property we can merge to be one(avoiding repetation of code)
        public DateTime? Deudate { get; set; }
        #endregion

     

       
    }
}
