using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
  public  class Ticket
    {
        public int? TicketId { get; set; }


        
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        [StringLength(50)]
        public string Owner { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? Deudate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        #region Navigation Property


        public int? ProjectId { get; set; }
        public Project Projects { get; set; }
        #endregion


    }
}
