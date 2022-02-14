using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
  public  class Project
    {
        #region Scalar  property
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "name cant be empty")]
        [StringLength(50)]
        public string Name { get; set; }
        #endregion

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        #region Collection navigation Property
        //its a good practise to always initialsed collection navigation property
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        #endregion

    }
}
