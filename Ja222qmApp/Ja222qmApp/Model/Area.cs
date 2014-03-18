using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ja222qmApp.Model
{
    public class Area
    {
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Ansvarsområdets namn måste anges")]
        [StringLength(15, ErrorMessage = "Ansvarsområdet får ha max 15 tecken.")]
        public string AreaName { get; set; }
    }
}