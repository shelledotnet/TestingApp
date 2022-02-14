using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Dtos
{
    
    public class ProjectDto
    {
        #region Scalar  property
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "name cant be empty")]
        [StringLength(50)]
        public string Name { get; set; }
        #endregion

       

    }
}
